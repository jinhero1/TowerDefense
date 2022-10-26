using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class Patrol : MonoBehaviour
    {
        private const int ZERO = 0;

        [SerializeField] private SpriteRenderer spriteRenderer;

        private int pointIndex;
        private Vector3 nextPosition;

        public int Id { get; private set; }
        public EnemyConfiguration Configuration { get; private set; }

        public void SetData(int pId, EnemyConfiguration pConfiguration)
        {
            Id = pId;
            Configuration = pConfiguration;

            spriteRenderer.sprite = pConfiguration.Image;
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
            MessageBroker.Default.Publish(new PatrolArrivalDestinationArgs(Configuration.Type));
        }

        private void Update()
        {
            if (Configuration == null) return;

            this.transform.position = Vector2.MoveTowards(this.transform.position, nextPosition, Configuration.Speed * Time.deltaTime);

            if (Vector2.Distance(this.transform.position, nextPosition) == ZERO)
            {
                ChangeNextPositionIfNeeded();
            }
        }
    }
}