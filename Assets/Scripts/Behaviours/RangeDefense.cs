using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class RangeDefense : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private string targetTag;
        [SerializeField] private CollisionDetector range;
        [SerializeField] private LookAtTarget lookAt;

        private TowerConfiguration configuration;
        private GameObject target;
        private AsyncReactiveCommand cooldownCommand;

        private void Awake()
        {
            range.SetData(OnTargetChanged);
        }

        public void SetData(TowerConfiguration pConfiguration)
        {
            configuration = pConfiguration;

            GameServices.TowerController.SetTower(pConfiguration.Type, spriteRenderer, range.transform);

            cooldownCommand?.Dispose();
            cooldownCommand = new AsyncReactiveCommand();
            cooldownCommand.Subscribe(_ =>
            {
                return Observable.Timer(TimeSpan.FromSeconds(pConfiguration.WaitingTime)).AsUnitObservable();
            });
            cooldownCommand.CanExecute.Where(x => x == true).Subscribe(_ => OnCountdownFinished());
        }

        private void OnTargetChanged(IEnumerable<GameObject> pEnumerable, bool isEnterEvent)
        {
            target = pEnumerable.Where(x => x.tag == targetTag).FirstOrDefault();

            if (isEnterEvent)
            {
                NotifyFireIfCanExecute();
            }
        }

        private void OnCountdownFinished()
        {
            if (target == null) return;

            NotifyFireIfCanExecute();
        }

        private void NotifyFireIfCanExecute()
        {
            if (!cooldownCommand.CanExecute.Value) return;            
            if (GameServices.GameDataManager.NeedStopFire) return;

            lookAt?.SetTarget(target.transform);

            cooldownCommand.Execute();
            MessageBroker.Default.Publish(new CombatArgs(this, configuration.Attack, target.GetComponent<Patrol>()));
        }
    }
}