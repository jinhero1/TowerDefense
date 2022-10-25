using UnityEngine;

namespace TowerDefense
{
    public class RangeDefense : MonoBehaviour
    {
        [SerializeField] private Transform range;

        private TowerConfiguration configuration;

        public void SetData(TowerConfiguration pConfiguration)
        {
            configuration = pConfiguration;

            GameServices.TowerController.SetRange(pConfiguration.Type, range);
        }
    }
}