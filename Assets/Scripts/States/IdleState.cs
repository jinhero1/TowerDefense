using System;
using UniRx;

namespace TowerDefense
{
    public class IdleState : BaseState
    {
        private IDisposable disposable;

        public override void OnEnter()
        {
            GameServices.EnemyController.NextWave();

            MessageBroker.Default.Receive<PatrolArrivalDestinationArgs>().Subscribe(OnPatrolArrivalDestination);
            disposable = GameServices.GameDataManager.PlayerData.IsDead.Where(x => x == true).Subscribe(_ =>
            {
                disposable.Dispose();

                Next();
            });
        }

        private void OnPatrolArrivalDestination(PatrolArrivalDestinationArgs pArgs)
        {
            int enemyTypeIndex = (int)pArgs.EnemyType;

            EnemyConfiguration configuration = GameServices.GameAssetManager.EnemyConfigurations.GetConfiguration(enemyTypeIndex);
            GameServices.GameDataManager.PlayerData.HP.Value -= configuration.Attack;
        }
    }
}