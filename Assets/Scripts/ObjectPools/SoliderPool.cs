using UniRx.Toolkit;
using UnityEngine;

namespace TowerDefense
{
    public class SoliderPool : ObjectPool<Patrol>
    {
        private EnemyConfiguration configuration;
        private Transform hierarchyParent;

        public SoliderPool(EnemyConfiguration pConfiguration)
        {
            configuration = pConfiguration;
            hierarchyParent = new GameObject($"{pConfiguration.Prefab.name}Pool").transform;
        }

        protected override Patrol CreateInstance()
        {
            GameObject instance = GameObject.Instantiate(configuration.Prefab, hierarchyParent) as GameObject;
            Patrol patrol = instance.GetComponent<Patrol>();
            patrol.SetData(configuration.Type, configuration.Speed);

            return patrol;
        }
    }
}