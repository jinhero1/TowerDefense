namespace TowerDefense
{
    public class CombatArgs
    {
        public RangeDefense Tower { get; private set; }
        public int Attack { get; private set; }
        public Patrol Enemy { get; private set; }

        public CombatArgs(RangeDefense pTower, int pAttack, Patrol pEnemy)
        {
            Tower = pTower;
            Attack = pAttack;
            Enemy = pEnemy;
        }
    }
}