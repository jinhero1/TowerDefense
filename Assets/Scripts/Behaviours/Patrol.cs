using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class Patrol : MonoBehaviour
    {
        private const int ZERO = 0;

        private EnemyType enemyType;
        private int speed;
        private int pointIndex;
        private Vector3 nextPosition;

        public void SetData(EnemyType pEnemyType, int pSpeed)
        {
            enemyType = pEnemyType;
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
            Vector3Int point = GameServices.GameAssetManager.MapConfiguration.GetPatrolPoint(pIndex);

            return GameServices.GameMapManager.Tilemap.GetCellCenterWorld(point);
        }

        private void ChangeNextPositionIfNeeded()
        {
            pointIndex++;

            if (GameServices.GameAssetManager.MapConfiguration.HasPatrolPoint(pointIndex))
            {
                nextPosition = GetPosition(pointIndex);
            }
            else
            {
                OnArrivalDestination();
            }
        }

        private void OnArrivalDestination()
        {
            GameServices.EnemyController.Return(this);
            MessageBroker.Default.Publish(new PatrolArrivalDestinationArgs(enemyType));
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