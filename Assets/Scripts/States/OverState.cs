using Library;
using UniRx;

namespace TowerDefense
{
    public class OverState : BaseState
    {
        private void Awake()
        {
            MessageBroker.Default.Receive<RestartGameArgs>().Subscribe(_ =>
            {
                Next();
            });
        }

        public override void OnEnter()
        {
            TimeUtility.Pause();

            bool isWin = true;
            if (GameServices.GameDataManager.PlayerData.IsDead.Value)
            {
                isWin = false;
            }

            MessageBroker.Default.Publish(new GameResultArgs(isWin));
        }
    }
}