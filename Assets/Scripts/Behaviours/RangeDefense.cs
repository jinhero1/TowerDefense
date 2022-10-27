using System.Collections.Generic;
using System.Linq;
using Library;
using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class RangeDefense : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private CollisionDetector range;
        [SerializeField] private LookAtTarget lookAt;
        [SerializeField] private Flash muzzleFlash;

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
            muzzleFlash?.SetData(pConfiguration.MuzzleFlashType);

            cooldownCommand?.Dispose();
            cooldownCommand = AsyncReactiveCommandUtility.Create(pConfiguration.WaitingTime, OnCountdownFinished);
        }

        private void OnTargetChanged(IEnumerable<GameObject> pEnumerable, bool isEnterEvent)
        {
            target = pEnumerable.Where(x => LayerMaskUtility.IsInLayer(x.layer, targetLayer)).FirstOrDefault();

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
            muzzleFlash?.Display();

            cooldownCommand.Execute();
            MessageBroker.Default.Publish(new CombatArgs(this, configuration.Attack, target.GetComponent<Patrol>()));
        }
    }
}