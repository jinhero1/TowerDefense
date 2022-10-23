namespace TowerDefense
{
    public class InitializeState : BaseState
    {
        public override void OnEnter()
        {
            CommonServices.GameAssetManager.Load();

            Next();
        }
    }
}