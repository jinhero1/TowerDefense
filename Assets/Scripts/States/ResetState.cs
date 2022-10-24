namespace TowerDefense
{
    public class ResetState : BaseState
    {
        public override void OnEnter()
        {
            GameServices.GameDataManager.Reset(GameServices.GameAssetManager.PlayerConfiguration);

            Next();
        }
    }
}