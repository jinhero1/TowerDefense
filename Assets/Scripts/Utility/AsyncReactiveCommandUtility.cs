using System;
using UniRx;

namespace TowerDefense
{
    public class AsyncReactiveCommandUtility
    {
        private const int ONE_THOUSAND = 1000;

        public static AsyncReactiveCommand Create(float pSeconds, Action pCountdownCallback)
        {
            float milliseconds = pSeconds * ONE_THOUSAND;

            AsyncReactiveCommand command = new AsyncReactiveCommand();
            command.Subscribe(_ =>
            {
                return Observable.Timer(TimeSpan.FromMilliseconds(milliseconds)).AsUnitObservable();
            });
            command.CanExecute.Where(x => x == true).Subscribe(_ => pCountdownCallback?.Invoke());

            return command;
        }
    }
}