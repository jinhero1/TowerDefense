using Library;

namespace TowerDefense
{
    public class ResetState : BaseState
    {
        public override void OnEnter()
        {
            TimeUtility.Resume();
            GameServices.GameDataManager.Reset(GameServices.GameAssetManager.PlayerConfiguration, GameServices.GameAssetManager.WaveConfigurations);

            GameServices.EnemyController.Reset();
            GameServices.TowerController.Reset();

            Next();
        }
    }
}