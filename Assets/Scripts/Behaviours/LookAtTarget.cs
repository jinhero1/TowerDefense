using Library;
using UnityEngine;

namespace TowerDefense
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField] private float imageAngleOffset;

        public void SetTarget(Transform pTarget)
        {
            Vector2 direction = pTarget.position - this.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + imageAngleOffset;

            TransformUtility.SetAngle(this.transform, angle);
        }
    }
}