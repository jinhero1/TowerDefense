namespace TowerDefense
{
    public class DespawnEnemyArgs
    {
        public Patrol Target { get; private set; }

        public DespawnEnemyArgs(Patrol pTarget)
        {
            Target = pTarget;
        }
    }
}