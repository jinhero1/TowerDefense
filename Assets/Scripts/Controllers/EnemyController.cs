using Library;
using UniRx;

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
            pool.Rent();
        }

        public void Return(Patrol pTarget)
        {
            pool.Return(pTarget);
        }
    }
}