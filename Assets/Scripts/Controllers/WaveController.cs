using Library;
using UniRx;

namespace TowerDefense
{
    public class WaveController : IService
    {
        public void Initialize()
        {
            MessageBroker.Default.Receive<AllEnemiesDeadArgs>().Subscribe(_ => OnAllEnemiesDead());
        }

        public void Start()
        {
            OnNextWave();
        }

        private void OnAllEnemiesDead()
        {
            // TODO: If no enemies are still in queue.
            GameServices.GameDataManager.WaveData.Current.Value++;

            OnNextWave();
        }

        private void OnNextWave()
        {
            if (GameServices.GameDataManager.WaveData.IsOverMax())
            {
                MessageBroker.Default.Publish(new NoNextWaveArgs());
                return;
            }

            // TODO: Initial from wave configuration
            EnemyType enemyType = EnemyType.Warrior;
            GameServices.EnemyController.SpawnPatrol(enemyType);
        }
    }
}