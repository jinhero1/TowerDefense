using UniRx;

namespace TowerDefense
{
    public class IdleState : BaseState
    {
        public override void OnEnter()
        {
            GameServices.EnemyController.NextWave();

            MessageBroker.Default.Receive<PatrolArrivalDestinationArgs>().Subscribe(OnPatrolArrivalDestination);
            GameServices.GameDataManager.PlayerData.IsDead.Where(x => x == true).Subscribe(_ =>
            {
                UnityEngine.Debug.Log("Player is dead");
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