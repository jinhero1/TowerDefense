using System;
using Library;
using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class GameAssetManager : IService
    {
        public PlayerConfiguration PlayerConfiguration { get; private set; }
        public MapConfiguration MapConfiguration { get; private set; }
        public EnemyConfigurations EnemyConfigurations { get; private set; }
        public TowerConfigurations TowerConfigurations { get; private set; }
        public WaveConfigurations WaveConfigurations { get; private set; }

        public void Initialize()
        {            
        }

        public void Load()
        {
            Load<PlayerConfiguration>("PlayerConfiguration", (x) => { PlayerConfiguration = x; });
            Load<MapConfiguration>("MapConfiguration", (x) => { MapConfiguration = x; });
            Load<EnemyConfigurations>("EnemyConfigurations", (x) => { EnemyConfigurations = x; });
            Load<TowerConfigurations>("TowerConfigurations", (x) => { TowerConfigurations = x; });
            Load<WaveConfigurations>("WaveConfigurations", (x) => { WaveConfigurations = x; });

            MessageBroker.Default.Publish(new GameAssetReadyArgs());
        }

        private void Load<T>(string pFileNameWithoutExtension, Action<T> pOnCompleted) where T : ScriptableObject
        {
            AssetLoader.Load($"Asset/{pFileNameWithoutExtension}", pOnCompleted);
        }
    }
}