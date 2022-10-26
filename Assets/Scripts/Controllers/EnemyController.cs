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
            int typeIndex = (int)EnemyType.Warrior;
            EnemyConfiguration configuration = GameServices.GameAssetManager.EnemyConfigurations.GetConfiguration(typeIndex);
            pool = new EnemyPool(configuration);
        }

        public void Reset()
        {
            pool.ReturnAll();
            enemyId = 0;
        }

        public void SpawnPatrol(EnemyType pEnemyType)
        {
            Patrol patrol = pool.Rent();
            patrol.SetData(++enemyId, pool.Configuration);
            GameServices.GameDataManager.CreateEnemyData(patrol.Id, patrol.Configuration.HP);
        }

        public void Return(Patrol pTarget)
        {
            pool.Return(pTarget);
        }
    }
}