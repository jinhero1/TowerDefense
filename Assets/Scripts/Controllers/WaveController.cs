using System.Collections.Generic;
using Library;
using UniRx;

namespace TowerDefense
{
    public class WaveController : IService
    {
        private const int ZERO = 0;

        private AsyncReactiveCommand cooldownCommand;
        private Queue<EnemyType> enemyQueue;

        public void Initialize()
        {
            MessageBroker.Default.Receive<GameAssetReadyArgs>().Subscribe(_ => OnGameAssetReady());
            MessageBroker.Default.Receive<AllEnemiesDeadArgs>().Subscribe(_ => OnAllEnemiesDead());
        }

        public void Start()
        {
            OnNextWave();
        }

        private void OnGameAssetReady()
        {
            if (cooldownCommand == null)
            {
                float intervalTime = GameServices.GameAssetManager.WaveConfigurations.IntervalTime;
                cooldownCommand = AsyncReactiveCommandUtility.Create(intervalTime, OnCountdownFinished);
            }
        }

        private void OnAllEnemiesDead()
        {
            if (enemyQueue.Count > ZERO) return;

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

            int currentWave = GameServices.GameDataManager.WaveData.Current.Value;
            WaveConfiguration configuration = GameServices.GameAssetManager.WaveConfigurations.GetConfiguration(currentWave);
            enemyQueue = configuration.GetEnemyQueue();

            Execute();
        }

        private void OnCountdownFinished()
        {
            if (enemyQueue == null || enemyQueue.Count == ZERO) return;

            Execute();
        }

        private void Execute()
        {
            EnemyType enemyType = enemyQueue.Dequeue();
            NotifySpawnEnemy(enemyType);

            cooldownCommand.Execute();
        }

        private void NotifySpawnEnemy(EnemyType pType)
        {
            MessageBroker.Default.Publish(new SpawnEnemyArgs(pType));
        }
    }
}