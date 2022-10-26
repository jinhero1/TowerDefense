using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class Fire : MonoBehaviour
    {
        [SerializeField] private GameObject renderObject;
        [SerializeField] private float displayTime;

        private AsyncReactiveCommand cooldownCommand;

        private void Awake()
        {
            cooldownCommand = AsyncReactiveCommandUtility.Create(displayTime, OnCountdownFinished);
        }

        public void Execute()
        {
            renderObject.SetActive(true);
            cooldownCommand.Execute();
        }

        private void OnCountdownFinished()
        {
            renderObject.SetActive(false);
        }
    }
}