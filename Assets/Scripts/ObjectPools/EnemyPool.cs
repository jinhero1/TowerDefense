using UnityEngine;

namespace TowerDefense
{
    public class EnemyPool : BasePool<Patrol>
    {
        public EnemyPool(GameObject pPrefab) : base(pPrefab)
        {
        }

        protected override void OnCreatedInstance(Patrol pInstance)
        {
        }
    }
}