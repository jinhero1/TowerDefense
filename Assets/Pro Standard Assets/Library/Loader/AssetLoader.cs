using System;
using UnityEngine;

namespace Library
{
    public class AssetLoader
    {
        public static void Load<T>(string pPath, Action<T> pOnCompleted) where T : UnityEngine.Object
        {
            T asset = Resources.Load<T>(pPath);
            pOnCompleted?.Invoke(asset);
        }
    }
}