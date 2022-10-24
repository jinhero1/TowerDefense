using System;
using UnityEngine;

namespace TowerDefense
{
    [Serializable]
    public class EnemyConfiguration
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private int speed;
        [SerializeField] private int attack;
        [SerializeField] private GameObject prefab;

        public EnemyType Type => type;
        public int Speed => speed;
        public int Attack => attack;
        public GameObject Prefab => prefab;
    }

    [CreateAssetMenu(menuName = "Scriptable Object/Create Enemy Configurations")]
    public class EnemyConfigurations : ScriptableObject
    {
        [SerializeField] private EnemyConfiguration[] enemies;

        public EnemyConfiguration GetConfiguration(int pIndex)
        {
            return enemies[pIndex];
        }
    }
}