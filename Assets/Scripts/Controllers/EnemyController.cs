using Library;
using UniRx;

namespace TowerDefense
{
    public class EnemyController : IService
    {
        private EnemyPool pool = null;
        private int enemyId;

        public void Initialize()
        {
            MessageBroker.Default.Receive<NextWaveArgs>().Subscribe(x =>
            {
                if (!x.IsOverMax)
                {
                    OnNextWave();
                }
            });
            MessageBroker.Default.Receive<SpawnEnemyArgs>().Subscribe(OnSpawnEnemy);
            MessageBroker.Default.Receive<DespawnEnemyArgs>().Subscribe(OnDespawnEnemy);
        }

        public void Prepare()
        {
            pool = new EnemyPool(GameServices.GameAssetManager.EnemyConfigurations.Prefab);
        }

        public void Reset()
        {
            pool.ReturnAll();
            enemyId = 0;
        }

        private void OnNextWave()
        {
            enemyId = 0;
        }

        private void OnSpawnEnemy(SpawnEnemyArgs pArgs)
        {
            Patrol unit = pool.Rent();
            unit.SetData(++enemyId, GameServices.GameAssetManager.EnemyConfigurations.GetConfiguration(pArgs.EnemyType));

            GameServices.GameDataManager.CreateEnemyData(unit.Id, unit.Configuration.HP);
        }

        private void OnDespawnEnemy(DespawnEnemyArgs pArgs)
        {
            pool.Return(pArgs.Target);

            GameServices.GameDataManager.RemoveEnemyData(pArgs.Target.Id);
            // All enemies dead or no enemies
            if (GameServices.GameDataManager.AreAllEnemiesDead())
            {
                MessageBroker.Default.Publish(new AllEnemiesDeadArgs());
            }
        }
    }
}