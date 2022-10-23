namespace TowerDefense
{
    public class IdleState : BaseState
    {
        public override void OnEnter()
        {
            GameServices.EnemyController.NextWave();
        }
    }
}