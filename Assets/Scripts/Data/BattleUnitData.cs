using UniRx;

namespace TowerDefense
{
    public class BattleUnitData
    {
        private const int ZERO = 0;

        public IReactiveProperty<int> HP { get; private set; }
        public IReadOnlyReactiveProperty<bool> IsDead { get; private set; }

        public BattleUnitData(int pInitialHP)
        {
            HP = new ReactiveProperty<int>(pInitialHP);
            IsDead = HP.Select(x => x <= ZERO).ToReactiveProperty();
        }
    }
}