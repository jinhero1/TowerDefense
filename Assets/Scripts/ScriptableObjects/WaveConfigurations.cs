using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [Serializable]
    public class WaveConfiguration
    {
        [SerializeField] private EnemyType[] enemyTypes;

        public int GetEnemyCount()
        {
            return enemyTypes.Length;
        }

        public Queue<EnemyType> GetEnemyQueue()
        {
            return new Queue<EnemyType>(enemyTypes);
        }
    }

    [CreateAssetMenu(menuName = "Scriptable Object/Create Wave Configurations")]
    public class WaveConfigurations : ScriptableObject
    {
        private const int ONE = 1;

        [SerializeField] private float intervalTime;
        [SerializeField] private WaveConfiguration[] waves;

        public float IntervalTime => intervalTime;

        public WaveConfiguration GetConfiguration(int pWave)
        {
            return waves[pWave - ONE];
        }

        public int GetMaxWave()
        {
            return waves.Length;
        }

        public int GetMaxEnemyCount()
        {
            int maxEnemyCount = 0;
            int _enemyCount;

            for (int i = 0; i < waves.Length; i++)
            {
                _enemyCount = waves[i].GetEnemyCount();
                if (_enemyCount > maxEnemyCount)
                {
                    maxEnemyCount = _enemyCount;
                }
            }

            return maxEnemyCount;
        }
    }
}