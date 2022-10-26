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

            spriteRenderer.sprite = pConfiguration.Image;
            GameServices.TowerController.SetRange(pConfiguration.Type, range.transform);

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
                NotifyCombatIfCanExecute();
            }
        }

        private void OnCountdownFinished()
        {
            if (target == null) return;

            NotifyCombatIfCanExecute();
        }

        private void NotifyCombatIfCanExecute()
        {
            if (!cooldownCommand.CanExecute.Value) return;            
            if (GameServices.GameDataManager.NeedStopFire) return;

            cooldownCommand.Execute();
            MessageBroker.Default.Publish(new CombatArgs(this, configuration.Attack, target.GetComponent<Patrol>()));
        }
    }
}