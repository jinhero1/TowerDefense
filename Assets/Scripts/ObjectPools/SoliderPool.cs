using UniRx.Toolkit;
using UnityEngine;

namespace TowerDefense
{
    public class SoliderPool : ObjectPool<Patrol>
    {
        private Patrol prefab;

        public SoliderPool(Patrol pPrefab)
        {
            prefab = pPrefab;
        }

        protected override Patrol CreateInstance()
        {
            Patrol instance = GameObject.Instantiate<Patrol>(prefab);

            return instance;
        }
    }
}