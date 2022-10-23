using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "Scriptable Object/Create Patrol Points")]
    public class PatrolPoints : ScriptableObject
    {
        [SerializeField] private Vector2Int[] points;

        public Vector3Int GetPoint(int pIndex)
        {
            return (Vector3Int)points[pIndex];
        }
    }
}