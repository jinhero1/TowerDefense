using UnityEngine;

namespace TowerDefense
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private Patrol soliderPrefab;

        private SoliderPool soliderPool = null;

        public void NextWave()
        {
            soliderPool = new SoliderPool(soliderPrefab);

            soliderPool.Rent();
        }
    }
}