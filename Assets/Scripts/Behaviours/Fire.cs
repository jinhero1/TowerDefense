using System;
using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class Fire : MonoBehaviour
    {
        [SerializeField] private GameObject renderObject;
        [SerializeField] private float milliseconds;

        private AsyncReactiveCommand cooldownCommand;

        private void Awake()
        {
            cooldownCommand = new AsyncReactiveCommand();
            cooldownCommand.Subscribe(_ =>
            {                
                return Observable.Timer(TimeSpan.FromMilliseconds(milliseconds)).AsUnitObservable();
            });
            cooldownCommand.CanExecute.Where(x => x == true).Subscribe(_ => OnCountdownFinished());
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