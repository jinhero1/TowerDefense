using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class GameResultUI : MonoBehaviour
    {
        [SerializeField] private GameObject youWinPage;
        [SerializeField] private GameObject gameOverPage;
        [SerializeField] private Button retry;

        private void Awake()
        {
            MessageBroker.Default.Receive<GameResultArgs>().Subscribe(OnGameResult);
            retry.OnClickAsObservable().Subscribe(_ => {
                gameOverPage.SetActive(false);
                MessageBroker.Default.Publish(new RestartGameArgs());
            });
        }

        private void OnGameResult(GameResultArgs pArgs)
        {
            youWinPage.SetActive(pArgs.IsWin);
            gameOverPage.SetActive(!pArgs.IsWin);
        }
    }
}