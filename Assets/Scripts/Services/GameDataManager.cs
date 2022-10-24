using Library;

namespace TowerDefense
{
    public class GameDataManager : IService
    {
        public PlayerData PlayerData { get; private set; }

        public void Initialize()
        {
        }

        public void Reset()
        {
            // test
            PlayerData = new PlayerData(0, 10);
        }
    }
}