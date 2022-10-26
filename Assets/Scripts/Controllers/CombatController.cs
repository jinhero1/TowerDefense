using Library;
using UniRx;

namespace TowerDefense
{
    public class CombatController : IService
    {
        public void Initialize()
        {
            MessageBroker.Default.Receive<CombatArgs>().Subscribe(OnCombat);
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
                GameServices.GameDataManager.RemoveEnemyData(enemyId);
                GameServices.EnemyController.Return(pArgs.Enemy);

                if (GameServices.GameDataManager.AreAllEnemiesDead())
                {
                    MessageBroker.Default.Publish(new AllEnemiesDeadArgs());
                }
            }
        }
    }
}