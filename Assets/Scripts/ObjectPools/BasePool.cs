using Library;
using UniRx.Toolkit;
using UnityEngine;

namespace TowerDefense
{
    public abstract class BasePool<T> : ObjectPool<T> where T : UnityEngine.Component
    {
        private GameObject prefab;
        private Transform hierarchyParent;

        public BasePool(GameObject pPrefab)
        {
            prefab = pPrefab;
            hierarchyParent = new GameObject($"{pPrefab.name}Pool").transform;
        }

        public void ReturnAll()
        {
            GameObject childObject = null;
            for (int i = hierarchyParent.childCount - 1; i >= 0; i--)
            {
                childObject = hierarchyParent.GetChild(i).gameObject;
                if (childObject.activeSelf)
                {
                    base.Return(childObject.GetComponent<T>());
                }
            }
        }

        protected override T CreateInstance()
        {
            T unit = GameObjectUtility.InstantiateComponent<T>(prefab, hierarchyParent);
            OnCreatedInstance(unit);

            return unit;
        }

        protected abstract void OnCreatedInstance(T pInstance);
    }
}