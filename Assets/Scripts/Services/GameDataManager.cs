using Library;
using UniRx;

namespace TowerDefense
{
    public class GameDataManager : IService
    {
        public PlayerData PlayerData { get; private set; }

        public void Initialize()
        {
        }

        public void Reset(PlayerConfiguration pPlayerConfiguration)
        {
            PlayerData = new PlayerData(pPlayerConfiguration.Money, pPlayerConfiguration.HP);            
        }
    }
}