using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [Serializable]
    public class WaveConfiguration
    {
        [SerializeField] private EnemyType[] enemyTypes;

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
    }
}