using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TowerDefense
{
    public class RangeDefense : MonoBehaviour
    {
        [SerializeField] private string targetTag;
        [SerializeField] private CollisionDetector range;

        private TowerConfiguration configuration;
        private GameObject target;

        private void Awake()
        {
            range.SetData(OnTargetChanged);
        }

        public void SetData(TowerConfiguration pConfiguration)
        {
            configuration = pConfiguration;

            GameServices.TowerController.SetRange(pConfiguration.Type, range.transform);
        }

        private void OnTargetChanged(IEnumerable<GameObject> pEnumerable)
        {
            target = pEnumerable.Where(x => x.tag == targetTag).FirstOrDefault();
            Debug.Log($"Target: {target}");
        }
    }
}