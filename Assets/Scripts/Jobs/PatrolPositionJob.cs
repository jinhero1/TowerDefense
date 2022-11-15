using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Burst;

namespace TowerDefense
{
    [BurstCompile]
    public struct PatrolPositionJob : IJobParallelForTransform
    {
        private const int ZERO = 0;

        [ReadOnly] public NativeArray<int> Speeds;
        [ReadOnly] public NativeArray<Vector3> NextPositions;
        [WriteOnly] public float DeltaTime;

        public NativeArray<bool> AreReached;

        public void Execute(int pIndex, TransformAccess pTransformAccess)
        {
            pTransformAccess.position = Vector2.MoveTowards(pTransformAccess.position, NextPositions[pIndex], Speeds[pIndex] * DeltaTime);
            AreReached[pIndex] = Vector2.Distance(pTransformAccess.position, NextPositions[pIndex]) == ZERO;
        }
    }
}