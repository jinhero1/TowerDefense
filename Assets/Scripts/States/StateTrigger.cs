using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    public class StateTrigger : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent target;

        private void Awake()
        {
            target?.Invoke();
        }
    }
}