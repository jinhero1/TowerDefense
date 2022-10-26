using Library;

namespace TowerDefense
{
    public static class GameServices
    {
        private static readonly ServiceLocator serviceLocator = new ServiceLocator();

        private static readonly GameAssetManager gameAssetManager = serviceLocator.GetService<GameAssetManager>();
        private static readonly GameMapManager gameMapManager = serviceLocator.GetService<GameMapManager>();
        private static readonly GameDataManager gameDataManager = serviceLocator.GetService<GameDataManager>();
        private static readonly EnemyController enemyController = serviceLocator.GetService<EnemyController>();
        private static readonly InputController inputController = serviceLocator.GetService<InputController>();
        private static readonly TowerController towerController = serviceLocator.GetService<TowerController>();
        private static readonly WaveController waveController = serviceLocator.GetService<WaveController>();
        private static readonly CombatController combatController = serviceLocator.GetService<CombatController>();

        public static GameAssetManager GameAssetManager => gameAssetManager;
        public static GameMapManager GameMapManager => gameMapManager;
        public static GameDataManager GameDataManager => gameDataManager;
        public static EnemyController EnemyController => enemyController;
        public static InputController InputController => inputController;
        public static TowerController TowerController => towerController;
        public static WaveController WaveController => waveController;
        public static CombatController CombatController => combatController;
    }
}