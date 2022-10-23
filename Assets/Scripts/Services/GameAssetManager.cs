using System;
using Library;
using UnityEngine;

namespace TowerDefense
{
    public class GameAssetManager : IService
    {
        public PatrolPoints PatrolPoints { get; private set; }

        public void Initialize()
        {            
        }

        public void Load()
        {
            Load<PatrolPoints>("PatrolPoints", (x) => { PatrolPoints = x; });
        }

        private void Load<T>(string pFileNameWithoutExtension, Action<T> pOnCompleted) where T : ScriptableObject
        {
            AssetLoader.Load($"Asset/{pFileNameWithoutExtension}", pOnCompleted);
        }
    }
}