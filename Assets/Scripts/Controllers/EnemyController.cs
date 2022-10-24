using Library;

namespace TowerDefense
{
    public class EnemyController : IService
    {
        private SoliderPool soliderPool = null;

        public void Initialize()
        {
        }

        public void NextWave()
        {
            int enemyTypeIndex = (int)EnemyType.Warrior;

            EnemyConfiguration configuration = GameServices.GameAssetManager.EnemyConfigurations.GetConfiguration(enemyTypeIndex);
            soliderPool = new SoliderPool(configuration);

            soliderPool.Rent();
        }

        public void Return(Patrol pTarget)
        {
            soliderPool.Return(pTarget);
        }
    }
}