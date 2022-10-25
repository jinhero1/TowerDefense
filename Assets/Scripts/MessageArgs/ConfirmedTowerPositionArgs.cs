using UnityEngine;

namespace TowerDefense
{
    public class ConfirmedTowerPositionArgs
    {
        public TowerType TowerType { get; private set; }
        public Vector3Int CellPosition { get; private set; }
        public Vector3 CellWorldPosition { get; private set; }

        public ConfirmedTowerPositionArgs(TowerType pTowerType, Vector3Int pCellPosition, Vector3 pCellWorldPosition)
        {
            TowerType = pTowerType;
            CellPosition = pCellPosition;
            CellWorldPosition = pCellWorldPosition;
        }
    }
}