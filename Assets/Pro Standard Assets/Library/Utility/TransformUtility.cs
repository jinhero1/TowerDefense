using UnityEngine;

namespace Library
{
    public class TransformUtility
    {
        public static void SetAngle(Transform pTransform, float pAngle)
        {
            pTransform.rotation = Quaternion.AngleAxis(pAngle, Vector3.forward);
        }
    }
}