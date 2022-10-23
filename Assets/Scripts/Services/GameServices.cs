using Library;

namespace TowerDefense
{
    public static class GameServices
    {
        private static readonly ServiceLocator serviceLocator = new ServiceLocator();

        private static readonly GameAssetManager gameAssetManager = serviceLocator.GetService<GameAssetManager>();
        private static readonly GameMapManager gameMapManager = serviceLocator.GetService<GameMapManager>();
        private static readonly EnemyController enemyController = serviceLocator.GetService<EnemyController>();

        public static GameAssetManager GameAssetManager => gameAssetManager;
        public static GameMapManager GameMapManager => gameMapManager;
        public static EnemyController EnemyController => enemyController;
    }
}