namespace TowerDefense
{
    public class PatrolArrivalDestinationArgs
    {
        public EnemyType EnemyType { get; private set; }

        public PatrolArrivalDestinationArgs(EnemyType pEnemyType)
        {
            EnemyType = pEnemyType;
        }
    }
}