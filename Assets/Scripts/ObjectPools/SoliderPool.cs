using UniRx.Toolkit;
using UnityEngine;

namespace TowerDefense
{
    public class SoliderPool : ObjectPool<Patrol>
    {
        private EnemyConfiguration configuration;

        public SoliderPool(EnemyConfiguration pConfiguration)
        {
            configuration = pConfiguration;
        }

        protected override Patrol CreateInstance()
        {
            GameObject instance = GameObject.Instantiate(configuration.Prefab) as GameObject;
            Patrol patrol = instance.GetComponent<Patrol>();
            patrol.SetSpeed(configuration.Speed);

            return patrol;
        }
    }
}