using UnityEngine;

namespace Library
{
    public class LayerMaskUtility
    {
        private const int ONE = 1;

        public static bool IsInLayer(int pLayer, LayerMask pMask)
        {
            return pMask == (pMask | (ONE << pLayer));
        }
    }
}