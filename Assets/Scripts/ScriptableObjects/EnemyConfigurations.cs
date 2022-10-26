using System;
using UnityEngine;

namespace TowerDefense
{
    [Serializable]
    public class EnemyConfiguration
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private int hp;
        [SerializeField] private int speed;
        [SerializeField] private int attack;
        [SerializeField] private Sprite image;

        public EnemyType Type => type;
        public int HP => hp;
        public int Speed => speed;
        public int Attack => attack;
        public Sprite Image => image;
    }

    [CreateAssetMenu(menuName = "Scriptable Object/Create Enemy Configurations")]
    public class EnemyConfigurations : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private EnemyConfiguration[] enemies;

        public GameObject Prefab => prefab;

        public EnemyConfiguration GetConfiguration(EnemyType pType)
        {
            return enemies[(int)pType];
        }
    }
}