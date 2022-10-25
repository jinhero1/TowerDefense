using UniRx;

namespace TowerDefense
{
    public class PlayerData : BattleUnitData
    {
        public IReactiveProperty<int> Money { get; private set; }

        public PlayerData(int pInitialMoney, int pInitialHP) : base(pInitialHP)
        {
            Money = new ReactiveProperty<int>(pInitialMoney);
        }
    }
}