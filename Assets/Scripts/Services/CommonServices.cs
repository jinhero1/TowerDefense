using Library;

namespace TowerDefense
{
    public static class CommonServices
    {
        private static readonly ServiceLocator serviceLocator = new ServiceLocator();

        private static readonly GameAssetManager gameAssetManager = serviceLocator.GetService<GameAssetManager>();

        public static GameAssetManager GameAssetManager => gameAssetManager;
    }
}