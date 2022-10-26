using UnityEngine;

namespace TowerDefense
{
    public class TowerPool : BasePool<RangeDefense>
    {
        public TowerPool(GameObject pPrefab) : base(pPrefab)
        {
        }

        protected override void OnCreatedInstance(RangeDefense pInstance)
        {
        }
    }
}