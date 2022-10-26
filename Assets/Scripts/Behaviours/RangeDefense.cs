using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class RangeDefense : MonoBehaviour
    {
        [SerializeField] private string targetTag;
        [SerializeField] private CollisionDetector range;

        private TowerConfiguration configuration;
        private GameObject target;
        private AsyncReactiveCommand waitingCommand;

        private void Awake()
        {
            range.SetData(OnTargetChanged);
        }

        public void SetData(TowerConfiguration pConfiguration)
        {
            configuration = pConfiguration;

            GameServices.TowerController.SetRange(pConfiguration.Type, range.transform);

            waitingCommand?.Dispose();
            waitingCommand = new AsyncReactiveCommand();
            waitingCommand.Subscribe(_ =>
            {
                return Observable.Timer(TimeSpan.FromSeconds(pConfiguration.WaitingTime)).AsUnitObservable();
            });
            waitingCommand.CanExecute.Where(x => x == true).Subscribe(_ => OnCountdownFinished());
        }

        private void OnTargetChanged(IEnumerable<GameObject> pEnumerable, bool isEnterEvent)
        {
            target = pEnumerable.Where(x => x.tag == targetTag).FirstOrDefault();

            if (isEnterEvent)
            {
                ThrowFireCommandIfCanExecute();
            }
        }

        private void OnCountdownFinished()
        {
            if (target == null) return;

            ThrowFireCommandIfCanExecute();
        }

        private void ThrowFireCommandIfCanExecute()
        {
            if (!waitingCommand.CanExecute.Value) return;            
            if (GameServices.GameDataManager.NeedStopFire) return;

            waitingCommand.Execute();
            MessageBroker.Default.Publish(new CombatArgs(this, configuration.Attack, target.GetComponent<Patrol>()));
        }
    }
}