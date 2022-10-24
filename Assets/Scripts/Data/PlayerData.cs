using UniRx;

namespace TowerDefense
{
    public class PlayerData
    {
        private const int ZERO = 0;

        public IReactiveProperty<int> Money { get; private set; }
        public IReactiveProperty<int> HP { get; private set; }
        public IReadOnlyReactiveProperty<bool> IsDead { get; private set; }

        public PlayerData(int pInitialMoney, int pInitialHP)
        {
            Money = new ReactiveProperty<int>(pInitialMoney);
            HP = new ReactiveProperty<int>(pInitialHP);
            IsDead = HP.Select(x => x <= ZERO).ToReactiveProperty();
        }
    }
}