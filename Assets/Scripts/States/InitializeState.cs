namespace TowerDefense
{
    public class InitializeState : BaseState
    {
        public override void OnEnter()
        {
            GameServices.GameMapManager.Load();
            GameServices.GameAssetManager.Load();

            Next();
        }
    }
}