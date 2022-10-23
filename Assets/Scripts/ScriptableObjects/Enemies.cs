using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [Serializable]
    public class EnemyConfiguration
    {
        [SerializeField] private int speed;
        [SerializeField] private int attack;
        [SerializeField] private GameObject prefab;

        public int Speed => speed;
        public int Attack => attack;
        public GameObject Prefab => prefab;
    }

    [CreateAssetMenu(menuName = "Scriptable Object/Create Enemies")]
    public class Enemies : ScriptableObject
    {
        [SerializeField] private EnemyConfiguration[] enemies;

        public EnemyConfiguration GetConfiguration(int pIndex)
        {
            return enemies[pIndex];
        }
    }
}