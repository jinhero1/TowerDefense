using System;
using UnityEngine;

namespace TowerDefense
{
    [Serializable]
    public class TowerConfiguration
    {
        [SerializeField] private TowerType type;
        [SerializeField] private int range;
        [SerializeField] private int frequency;
        [SerializeField] private int attack;
        [SerializeField] private GameObject prefab;

        public TowerType Type => type;
        public int Range => range;
        public int Frequency => frequency;
        public int Attack => attack;
        public GameObject Prefab => prefab;
    }

    [CreateAssetMenu(menuName = "Scriptable Object/Create Tower Configurations")]
    public class TowerConfigurations : ScriptableObject
    {
        [SerializeField] private TowerConfiguration[] towers;

        public TowerConfiguration GetConfiguration(int pIndex)
        {
            return towers[pIndex];
        }
    }
}