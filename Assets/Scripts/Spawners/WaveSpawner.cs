using UnityEngine;

namespace TowerDefense
{
    public class WaveSpawner : MonoBehaviour
    {
        private SoliderPool soliderPool = null;

        public void NextWave()
        {
            EnemyConfiguration configuration = CommonServices.GameAssetManager.Enemies.GetConfiguration(0);
            soliderPool = new SoliderPool(configuration.Prefab);

            soliderPool.Rent();
        }
    }
}