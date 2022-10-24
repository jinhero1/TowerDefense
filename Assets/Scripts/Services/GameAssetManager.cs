using System;
using Library;
using UnityEngine;

namespace TowerDefense
{
    public class GameAssetManager : IService
    {
        public PlayerConfiguration PlayerConfiguration { get; private set; }
        public PatrolPoints PatrolPoints { get; private set; }
        public EnemyConfigurations EnemyConfigurations { get; private set; }

        public void Initialize()
        {            
        }

        public void Load()
        {
            Load<PlayerConfiguration>("PlayerConfiguration", (x) => { PlayerConfiguration = x; });
            Load<PatrolPoints>("PatrolPoints", (x) => { PatrolPoints = x; });
            Load<EnemyConfigurations>("EnemyConfigurations", (x) => { EnemyConfigurations = x; });
        }

        private void Load<T>(string pFileNameWithoutExtension, Action<T> pOnCompleted) where T : ScriptableObject
        {
            AssetLoader.Load($"Asset/{pFileNameWithoutExtension}", pOnCompleted);
        }
    }
}