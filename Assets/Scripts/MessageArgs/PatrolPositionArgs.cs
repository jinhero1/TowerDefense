using UnityEngine;

namespace TowerDefense
{
    public class PatrolPositionArgs
    {
        public int Id { get; private set; }
        public Transform Transform { get; private set; }
        public int Speed { get; private set; }
        public Vector3 NextPosition { get; private set; }

        public PatrolPositionArgs(int pId, Transform pTransform, int pSpeed, Vector3 pNextPosition)
        {
            Id = pId;
            Transform = pTransform;
            Speed = pSpeed;
            NextPosition = pNextPosition;
        }
    }
}