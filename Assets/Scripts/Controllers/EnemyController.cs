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
            MessageBroker.Default.Receive<SpawnEnemyArgs>().Subscribe(OnSpawnEnemy);
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

        private void OnSpawnEnemy(SpawnEnemyArgs pArgs)
        {
            EnemyConfiguration configuration = GameServices.GameAssetManager.EnemyConfigurations.GetConfiguration(pArgs.EnemyType);

            Patrol patrol = pool.Rent();
            patrol.SetData(++enemyId, configuration);
            GameServices.GameDataManager.CreateEnemyData(patrol.Id, patrol.Configuration.HP);
        }

        public void Return(Patrol pTarget)
        {
            pool.Return(pTarget);
        }
    }
}