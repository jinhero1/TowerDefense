using UnityEngine;

namespace Library
{
    public class GameObjectUtility
    {
        public static T InstantiateComponent<T>(GameObject pPrefab, Transform pParent) where T : Component
        {
            GameObject instance = GameObject.Instantiate(pPrefab, pParent) as GameObject;

            return instance.GetComponent<T>();
        }
    }
}