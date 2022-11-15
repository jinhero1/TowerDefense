using UniRx;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using System;

namespace TowerDefense
{
    public class PatrolSystem : MonoBehaviour
    {
        private TransformAccessArray accessArray;
        private NativeArray<int> speeds;
        private NativeArray<Vector3> nextPositions;
        private NativeArray<bool> areReached;
        private JobHandle patrolPositionJobHandle;

        private IDisposable gameAssetReadySubscriber;
        private IDisposable patrolPositionSubscriber;

        void Awake()
        {
            gameAssetReadySubscriber = MessageBroker.Default.Receive<GameAssetReadyArgs>().Subscribe(_ =>
            {
                int maxEnemyCount = GameServices.GameAssetManager.WaveConfigurations.GetMaxEnemyCount();

                accessArray = new TransformAccessArray(new Transform[maxEnemyCount + 1]);
                speeds = new NativeArray<int>(accessArray.length, Allocator.Persistent);
                nextPositions = new NativeArray<Vector3>(accessArray.length, Allocator.Persistent);
                areReached = new NativeArray<bool>(accessArray.length, Allocator.Persistent);
            });

            patrolPositionSubscriber = MessageBroker.Default.Receive<PatrolPositionArgs>().Subscribe(OnPatrolPosition);
        }

        void OnDestroy()
        {
            accessArray.Dispose();
            speeds.Dispose();
            nextPositions.Dispose();
            areReached.Dispose();

            gameAssetReadySubscriber.Dispose();
            patrolPositionSubscriber.Dispose();
        }

        private void OnPatrolPosition(PatrolPositionArgs pArgs)
        {
            int id = pArgs.Id;

            accessArray[id] = pArgs.Transform;
            speeds[id] = pArgs.Speed;
            nextPositions[id] = pArgs.NextPosition;
            areReached[id] = false;
        }

        void Update()
        {
            var job = new PatrolPositionJob()
            {
                Speeds = speeds,
                NextPositions = nextPositions,
                AreReached = areReached,
                DeltaTime = Time.deltaTime
            };

            patrolPositionJobHandle = job.Schedule(accessArray);
        }

        void LateUpdate()
        {
            patrolPositionJobHandle.Complete();

            for (int i = 0; i < areReached.Length; i++)
            {
                if (areReached[i])
                {
                    MessageBroker.Default.Publish(new PatrolArrivalNextPositionArgs(i));
                }
            }
        }
    }
}