using Library;
using UniRx;

namespace TowerDefense
{
    public class EnemyController : IService
    {
        private EnemyPool soliderPool = null;

        public void Initialize()
        {
            MessageBroker.Default.Receive<RestartGameArgs>().Subscribe(_ =>
            {
                soliderPool.Clear();
            });
        }

        public void Prepare()
        {
            int enemyTypeIndex = (int)EnemyType.Warrior;
            EnemyConfiguration configuration = GameServices.GameAssetManager.EnemyConfigurations.GetConfiguration(enemyTypeIndex);
            soliderPool = new EnemyPool(configuration);
        }

        public void NextWave()
        {
            soliderPool.Rent();
        }

        public void Return(Patrol pTarget)
        {
            soliderPool.Return(pTarget);
        }
    }
}