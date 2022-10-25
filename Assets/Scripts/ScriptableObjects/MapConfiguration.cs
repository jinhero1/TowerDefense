using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(menuName = "Scriptable Object/Create Map Configuration")]
    public class MapConfiguration : ScriptableObject
    {
        [SerializeField] private Vector2Int[] patrolPoints;
        [SerializeField] private RectInt[] placeableRanges;

        private Vector2Int _point;

        public bool IsInPlaceableRange(Vector3Int pCellPosition)
        {
            _point = (Vector2Int)pCellPosition;

            for (int i = 0; i < placeableRanges.Length; i++)
            {
                if (placeableRanges[i].Contains(_point))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasPatrolPoint(int pIndex)
        {
            return pIndex >= 0 && pIndex < patrolPoints.Length;
        }

        public Vector3Int GetPatrolPoint(int pIndex)
        {
            return (Vector3Int)patrolPoints[pIndex];
        }
    }
}