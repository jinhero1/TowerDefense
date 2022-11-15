using System;
using UniRx;

namespace TowerDefense
{
    public class IdleState : BaseState
    {
        private IDisposable disposable;

        private void Awake()
        {
            MessageBroker.Default.Receive<NextWaveArgs>().Subscribe(x =>
            {
                if (x.IsOverMax)
                {
                    Next();
                }
            });
        }

        public override void OnEnter()
        {
            GameServices.WaveController.Start();

            disposable = GameServices.GameDataManager.PlayerData.IsDead.Where(x => x == true).Subscribe(_ =>
            {
                disposable.Dispose();

                Next();
            });
        }
    }
}