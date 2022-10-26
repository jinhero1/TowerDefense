using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class CollisionDetector : MonoBehaviour
    {
        private List<GameObject> targets = new List<GameObject>();
        private Action<IEnumerable<GameObject>, bool> changedCallback;

        public void SetData(Action<IEnumerable<GameObject>, bool> pChangedCallback)
        {
            changedCallback = pChangedCallback;
        }

        private void OnTriggerEnter2D(Collider2D pOther)
        {
            targets.Add(pOther.gameObject);
            changedCallback?.Invoke(targets, true);
        }

        private void OnTriggerExit2D(Collider2D pOther)
        {
            targets.Remove(pOther.gameObject);
            changedCallback?.Invoke(targets, false);
        }
    }
}