using Library;

namespace TowerDefense
{
    public static class CommonServices
    {
        private static readonly ServiceLocator serviceLocator = new ServiceLocator();

        private static readonly GameAssetManager gameAssetManager = serviceLocator.GetService<GameAssetManager>();
        private static readonly GameMapManager gameMapManager = serviceLocator.GetService<GameMapManager>();

        public static GameAssetManager GameAssetManager => gameAssetManager;
        public static GameMapManager GameMapManager => gameMapManager;
    }
}