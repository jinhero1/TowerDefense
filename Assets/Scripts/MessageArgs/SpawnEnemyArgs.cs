namespace TowerDefense
{
    public class SpawnEnemyArgs
    {
        public EnemyType EnemyType { get; private set; }

        public SpawnEnemyArgs(EnemyType pEnemyType)
        {
            EnemyType = pEnemyType;
        }
    }
}