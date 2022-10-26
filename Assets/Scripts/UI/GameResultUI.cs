using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Library;

namespace TowerDefense
{
    public class GameResultUI : MonoBehaviour
    {
        [SerializeField] private GameObject youWinPage;
        [SerializeField] private GameObject gameOverPage;
        [SerializeField] private Button retry;
        [SerializeField] private Button exit;

        private void Awake()
        {
            MessageBroker.Default.Receive<GameResultArgs>().Subscribe(OnGameResult);
            retry.OnClickAsObservable().Subscribe(_ => {
                gameOverPage.SetActive(false);
                MessageBroker.Default.Publish(new RestartGameArgs());
            });
            exit.OnClickAsObservable().Subscribe(_ =>
            {
                ApplicationUtility.Quit();
            });
        }

        private void OnGameResult(GameResultArgs pArgs)
        {
            youWinPage.SetActive(pArgs.IsWin);
            gameOverPage.SetActive(!pArgs.IsWin);
        }
    }
}