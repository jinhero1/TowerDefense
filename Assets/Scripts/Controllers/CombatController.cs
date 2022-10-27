using Library;
using UniRx;

namespace TowerDefense
{
    public class CombatController : IService
    {
        public void Initialize()
        {
            MessageBroker.Default.Receive<CombatArgs>().Subscribe(OnCombat);
            MessageBroker.Default.Receive<PatrolArrivalDestinationArgs>().Subscribe(OnPatrolArrivalDestination);
            MessageBroker.Default.Receive<GameResultArgs>().Subscribe(_ =>
            {
                GameServices.GameDataManager.SetStopFireFlag();
            });
        }

        private void OnCombat(CombatArgs pArgs)
        {
            int enemyId = pArgs.Enemy.Id;

            EnemyData enemyData = GameServices.GameDataManager.GetEnemyData(enemyId);
            enemyData.HP.Value -= pArgs.Attack;

            if (enemyData.IsDead.Value)
            {
                GameServices.EnemyController.Return(pArgs.Enemy);
            }
        }

        private void OnPatrolArrivalDestination(PatrolArrivalDestinationArgs pArgs)
        {
            EnemyConfiguration configuration = GameServices.GameAssetManager.EnemyConfigurations.GetConfiguration(pArgs.EnemyType);
            GameServices.GameDataManager.PlayerData.HP.Value -= configuration.Attack;
        }
    }
}