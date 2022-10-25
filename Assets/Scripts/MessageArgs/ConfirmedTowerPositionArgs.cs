using UnityEngine;

namespace TowerDefense
{
    public class ConfirmedTowerPositionArgs
    {
        public TowerType TowerType { get; private set; }
        public Vector3 Position { get; private set; }

        public ConfirmedTowerPositionArgs(TowerType pTowerType, Vector3 pPosition)
        {
            TowerType = pTowerType;
            Position = pPosition;
        }
    }
}