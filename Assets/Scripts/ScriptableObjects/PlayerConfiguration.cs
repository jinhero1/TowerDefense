using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "Scriptable Object/Create Player Configuration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField] private int money;
        [SerializeField] private int hp;

        public int Money => money;
        public int HP => hp;
    }
}