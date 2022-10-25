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
        [SerializeField] private GameObject prefab;
        [SerializeField] private Sprite icon;

        public TowerType Type => type;
        public int Range => range;
        public int WaitingTime => waitingTime;
        public int Attack => attack;
        public GameObject Prefab => prefab;
        public Sprite Icon => icon;
    }

    [CreateAssetMenu(menuName = "Scriptable Object/Create Tower Configurations")]
    public class TowerConfigurations : ScriptableObject
    {
        [SerializeField] private TowerConfiguration[] towers;

        public TowerConfiguration GetConfiguration(TowerType pType)
        {
            return towers[(int)pType];
        }

        public int GetRange(TowerType pType)
        {
            return GetConfiguration(pType).Range;
        }
    }
}