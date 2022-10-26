using Library;

namespace TowerDefense
{
    public class EnemyController : IService
    {
        private EnemyPool pool = null;

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
        }

        public void NextWave()
        {
            SpawnPatrol();
        }

        private void SpawnPatrol()
        {
            Patrol patrol = pool.Rent();
            patrol.Reset();
        }

        public void Return(Patrol pTarget)
        {
            pool.Return(pTarget);
        }
    }
}