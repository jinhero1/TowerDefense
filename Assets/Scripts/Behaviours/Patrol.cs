using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class Patrol : MonoBehaviour
    {
        private const int ZERO = 0;

        private EnemyConfiguration configuration;
        private EnemyData data;
        private int pointIndex;
        private Vector3 nextPosition;

        public void SetData(EnemyConfiguration pConfiguration)
        {
            configuration = pConfiguration;
        }

        public void Reset()
        {
            data = new EnemyData(configuration.HP);
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
            MessageBroker.Default.Publish(new PatrolArrivalDestinationArgs(configuration.Type));
        }

        private void Update()
        {
            if (configuration == null) return;

            this.transform.position = Vector2.MoveTowards(this.transform.position, nextPosition, configuration.Speed * Time.deltaTime);

            if (Vector2.Distance(this.transform.position, nextPosition) == ZERO)
            {
                ChangeNextPositionIfNeeded();
            }
        }
    }
}