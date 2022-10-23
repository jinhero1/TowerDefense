using UnityEngine;

namespace TowerDefense
{
    public class Patrol : MonoBehaviour
    {
        private int pointIndex;

        private void OnEnable()
        {
            pointIndex = 0;
            Vector3Int point = CommonServices.GameAssetManager.PatrolPoints.GetPoint(pointIndex);
            Vector3 position = CommonServices.GameMapManager.Tilemap.GetCellCenterWorld(point);
            this.gameObject.transform.position = position;
        }
    }
}