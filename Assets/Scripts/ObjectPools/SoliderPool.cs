using UniRx.Toolkit;
using UnityEngine;

namespace TowerDefense
{
    public class SoliderPool : ObjectPool<Patrol>
    {
        private GameObject prefab;

        public SoliderPool(GameObject pPrefab)
        {
            prefab = pPrefab;
        }

        protected override Patrol CreateInstance()
        {
            GameObject instance = GameObject.Instantiate(prefab) as GameObject;

            return instance.GetComponent<Patrol>();
        }
    }
}