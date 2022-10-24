using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class GameResultUI : MonoBehaviour
    {
        [SerializeField] private GameObject youWinPage;
        [SerializeField] private GameObject gameOverPage;

        private void Awake()
        {
            MessageBroker.Default.Receive<GameResultArgs>().Subscribe(OnGameResult);
        }

        private void OnGameResult(GameResultArgs pArgs)
        {
            youWinPage.SetActive(pArgs.IsWin);
            gameOverPage?.SetActive(!pArgs.IsWin);
        }
    }
}