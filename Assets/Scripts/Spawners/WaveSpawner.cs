using UnityEngine;

namespace TowerDefense
{
    public class WaveSpawner : MonoBehaviour
    {
        private SoliderPool soliderPool = null;

        public void NextWave()
        {
            int enemyIndex = (int)EnemyType.Warrior;

            EnemyConfiguration configuration = CommonServices.GameAssetManager.Enemies.GetConfiguration(enemyIndex);
            soliderPool = new SoliderPool(configuration);

            soliderPool.Rent();
        }
    }
}