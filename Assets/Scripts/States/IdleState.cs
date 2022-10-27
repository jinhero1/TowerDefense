using System;
using UniRx;

namespace TowerDefense
{
    public class IdleState : BaseState
    {
        private IDisposable disposable;

        private void Awake()
        {
            MessageBroker.Default.Receive<NoNextWaveArgs>().Subscribe(_ =>
            {
                Next();
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