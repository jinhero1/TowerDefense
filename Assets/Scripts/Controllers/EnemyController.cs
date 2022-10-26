using Library;

namespace TowerDefense
{
    public class EnemyController : IService
    {
        private EnemyPool pool = null;
        private int enemyId;

        public void Initialize()
        {
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

        public void Spawn(EnemyType pEnemyType)
        {
            EnemyConfiguration configuration = GameServices.GameAssetManager.EnemyConfigurations.GetConfiguration(pEnemyType);

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