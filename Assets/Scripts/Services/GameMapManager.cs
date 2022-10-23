using System;
using Library;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TowerDefense
{
    public class GameMapManager : IService
    {
        public Tilemap Tilemap { get; private set; }

        public void Initialize()
        {
        }

        public void Load()
        {
            SpawnThenGet<Tilemap>("Grid", (x) => { Tilemap = x; });
        }

        private void SpawnThenGet<T>(string pFileNameWithoutExtension, Action<T> pOnCompleted) where T : UnityEngine.Object
        {
            Load<UnityEngine.Object>(pFileNameWithoutExtension, (x) => {
                GameObject instance = GameObject.Instantiate(x) as GameObject;
                T component = instance.GetComponentInChildren<T>();

                pOnCompleted?.Invoke(component);
            });
        }

        private void Load<T>(string pFileNameWithoutExtension, Action<T> pOnCompleted) where T : UnityEngine.Object
        {
            AssetLoader.Load($"Map/{pFileNameWithoutExtension}", pOnCompleted);
        }
    }
}