using System.Collections.Generic;
using Library;
using UnityEngine;

namespace TowerDefense
{
    public class GameDataManager : IService
    {
        public PlayerData PlayerData { get; private set; }

        private List<Vector3Int> occupied = new List<Vector3Int>();

        public void Initialize()
        {
        }

        public void Reset(PlayerConfiguration pPlayerConfiguration)
        {
            PlayerData = new PlayerData(pPlayerConfiguration.Money, pPlayerConfiguration.HP);
            occupied.Clear();
        }

        public void Occupy(Vector3Int pCellPosition)
        {
            occupied.Add(pCellPosition);
        }

        public bool IsInOccupying(Vector3Int pCellPosition)
        {
            return occupied.Contains(pCellPosition);
        }
    }
}