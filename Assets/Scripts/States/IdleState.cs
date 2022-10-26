using System;
using UniRx;

namespace TowerDefense
{
    public class IdleState : BaseState
    {
        private IDisposable disposable;

        private void Awake()
        {
            MessageBroker.Default.Receive<CombatArgs>().Subscribe(OnCombat);
            MessageBroker.Default.Receive<PatrolArrivalDestinationArgs>().Subscribe(OnPatrolArrivalDestination);
        }

        public override void OnEnter()
        {
            GameServices.EnemyController.NextWave();

            disposable = GameServices.GameDataManager.PlayerData.IsDead.Where(x => x == true).Subscribe(_ =>
            {
                disposable.Dispose();

                Next();
            });
        }

        private void OnCombat(CombatArgs pArgs)
        {
            UnityEngine.Debug.Log($"{pArgs.Tower} attack {pArgs.Enemy}");
        }

        private void OnPatrolArrivalDestination(PatrolArrivalDestinationArgs pArgs)
        {
            int enemyTypeIndex = (int)pArgs.EnemyType;

            EnemyConfiguration configuration = GameServices.GameAssetManager.EnemyConfigurations.GetConfiguration(enemyTypeIndex);
            GameServices.GameDataManager.PlayerData.HP.Value -= configuration.Attack;
        }
    }
}