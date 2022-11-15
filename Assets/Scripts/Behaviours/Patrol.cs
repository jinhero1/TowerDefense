using System;
using Library;
using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class Patrol : MonoBehaviour
    {
        private const int ZERO = 0;

        [SerializeField] private SpriteRenderer spriteRenderer;

        private int pointIndex;
        private float currentAngle;
        private Vector3 nextPosition;
        private IDisposable subscriber;

        public int Id { get; private set; }
        public EnemyConfiguration Configuration { get; private set; }

        void Awake()
        {
            subscriber = MessageBroker.Default.Receive<PatrolArrivalNextPositionArgs>().Subscribe(OnPatrolArrivalNextPosition);
        }

        void OnDestroy()
        {
            subscriber.Dispose();
        }

        private void OnPatrolArrivalNextPosition(PatrolArrivalNextPositionArgs pArgs)
        {
            if (Id == pArgs.Id)
            {
                ChangeNextPositionIfNeeded();
            }
        }

        public void SetData(int pId, EnemyConfiguration pConfiguration)
        {
            Id = pId;
            Configuration = pConfiguration;

            spriteRenderer.sprite = pConfiguration.Image;

            ChangeNextPositionIfNeeded();
        }

        private void OnEnable()
        {
            pointIndex = ZERO;
            this.transform.position = GetPosition(pointIndex);
        }

        private Vector3 GetPosition(int pIndex)
        {
            Vector3Int point = GameServices.GameAssetManager.MapConfiguration.GetPatrolPoint(pIndex);

            return GameServices.GameMapManager.Tilemap.GetCellCenterWorld(point);
        }

        private void ChangeNextPositionIfNeeded()
        {
            currentAngle = GameServices.GameAssetManager.MapConfiguration.GetPatrolAngle(pointIndex);
            pointIndex++;

            if (GameServices.GameAssetManager.MapConfiguration.HasPatrolPoint(pointIndex))
            {
                nextPosition = GetPosition(pointIndex);
                TransformUtility.SetAngle(this.transform, currentAngle);

                MessageBroker.Default.Publish(new PatrolPositionArgs(Id, this.transform, Configuration.Speed, nextPosition));
            }
            else
            {
                OnArrivalDestination();
            }
        }

        private void OnArrivalDestination()
        {
            MessageBroker.Default.Publish(new DespawnEnemyArgs(this));
            MessageBroker.Default.Publish(new PatrolArrivalDestinationArgs(Configuration.Type));
        }
    }
}