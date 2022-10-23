using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    public abstract class BaseState : MonoBehaviour
    {
        [SerializeField]
        protected UnityEvent onNext;

        protected void Next()
        {
            onNext?.Invoke();
        }

        public abstract void OnEnter();        
    }
}