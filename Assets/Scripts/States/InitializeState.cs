namespace TowerDefense
{
    public class InitializeState : BaseState
    {
        public override void OnEnter()
        {
            CommonServices.GameMapManager.Load();
            CommonServices.GameAssetManager.Load();

            Next();
        }
    }
}