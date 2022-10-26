using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class Flash : MonoBehaviour
    {
        [SerializeField] private GameObject[] renderObjects;
        [SerializeField] private float displayTime;

        private GameObject renderObject;
        private AsyncReactiveCommand cooldownCommand;

        private void Awake()
        {
            cooldownCommand = AsyncReactiveCommandUtility.Create(displayTime, OnCountdownFinished);
        }

        public void SetData(FlashType pType)
        {
            for (int i = 0; i < renderObjects.Length; i++)
            {
                renderObjects[i].SetActive(false);
            }

            renderObject = renderObjects[(int)pType];
        }

        public void Display()
        {
            renderObject.SetActive(true);
            cooldownCommand.Execute();
        }

        private void OnCountdownFinished()
        {
            renderObject?.SetActive(false);
        }
    }
}