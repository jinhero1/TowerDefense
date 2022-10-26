using System.Collections.Generic;
using Library;
using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class GameDataManager : IService
    {
        public PlayerData PlayerData { get; private set; }
        public WaveData WaveData { get; private set; }
        public bool NeedStopFire { get; private set; }

        private List<Vector3Int> occupied = new List<Vector3Int>();
        private Dictionary<int, EnemyData> enemies = new Dictionary<int, EnemyData>();

        public void Initialize()
        {
        }

        public void Reset(PlayerConfiguration pPlayerConfiguration, WaveConfigurations pWaveConfigurations)
        {
            PlayerData = new PlayerData(pPlayerConfiguration.Money, pPlayerConfiguration.HP);
            WaveData = new WaveData(pWaveConfigurations.GetMaxWave());
            NeedStopFire = false;
            occupied.Clear();
            enemies.Clear();

            MessageBroker.Default.Publish(new GameDataReadyArgs());
        }

        public void AddOccupying(Vector3Int pCellPosition)
        {
            occupied.Add(pCellPosition);
        }

        public bool IsInOccupying(Vector3Int pCellPosition)
        {
            return occupied.Contains(pCellPosition);
        }

        public void SetStopFireFlag()
        {
            NeedStopFire = true;
        }

        public void CreateEnemyData(int pId, int pInitialHP)
        {
            enemies.Add(pId, new EnemyData(pInitialHP));
        }

        public void RemoveEnemyData(int pId)
        {
            enemies.Remove(pId);
        }

        public EnemyData GetEnemyData(int pId)
        {
            return enemies[pId];
        }

        public bool AreAllEnemiesDead()
        {
            foreach (EnemyData data in enemies.Values)
            {
                if (!data.IsDead.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}