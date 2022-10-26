using System;
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
            foreach (int typeIndex in Enum.GetValues(typeof(EnemyType)))
            {
                NotifySpawnEnemy((EnemyType)typeIndex);
            }
        }

        private void NotifySpawnEnemy(EnemyType pType)
        {
            MessageBroker.Default.Publish(new SpawnEnemyArgs(pType));
        }
    }
}