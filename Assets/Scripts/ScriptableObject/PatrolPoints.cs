using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "Scriptable Object/Create Patrol Points")]
    public class PatrolPoints : ScriptableObject
    {
        [SerializeField] private Vector2Int[] points;

        public Vector2 GetPoint(int pIndex)
        {
            return points[pIndex];
        }
    }
}