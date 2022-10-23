using UnityEngine;

namespace TowerDefense
{
    public class Patrol : MonoBehaviour
    {
        private const int ZERO = 0;

        private int speed;
        private int pointIndex;
        private Vector3 nextPosition;

        public void SetSpeed(int pSpeed)
        {
            speed = pSpeed;
        }

        private void OnEnable()
        {
            pointIndex = ZERO;
            this.transform.position = GetPosition(pointIndex);

            ChangeNextPositionIfNeeded();
        }

        private Vector3 GetPosition(int pIndex)
        {
            Vector3Int point = GameServices.GameAssetManager.PatrolPoints.GetPoint(pIndex);

            return GameServices.GameMapManager.Tilemap.GetCellCenterWorld(point);
        }

        private void ChangeNextPositionIfNeeded()
        {
            pointIndex++;

            if (GameServices.GameAssetManager.PatrolPoints.HasPoint(pointIndex))
            {
                nextPosition = GetPosition(pointIndex);
            }
            else
            {
                GameServices.EnemyController.Return(this);
            }
        }

        private void Update()
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, nextPosition, speed * Time.deltaTime);

            if (Vector2.Distance(this.transform.position, nextPosition) == ZERO)
            {
                ChangeNextPositionIfNeeded();
            }
        }
    }
}