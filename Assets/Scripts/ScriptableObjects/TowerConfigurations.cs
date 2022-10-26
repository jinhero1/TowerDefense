using System;
using UnityEngine;

namespace TowerDefense
{
    [Serializable]
    public class TowerConfiguration
    {
        [SerializeField] private TowerType type;
        [SerializeField] private int range;
        [SerializeField] private int waitingTime;
        [SerializeField] private int attack;
        [SerializeField] private Sprite image;

        public TowerType Type => type;
        public int Range => range;
        public int WaitingTime => waitingTime;
        public int Attack => attack;
        public Sprite Image => image;
    }

    [CreateAssetMenu(menuName = "Scriptable Object/Create Tower Configurations")]
    public class TowerConfigurations : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private TowerConfiguration[] towers;

        public GameObject Prefab => prefab;

        public TowerConfiguration GetConfiguration(TowerType pType)
        {
            return towers[(int)pType];
        }
    }
}