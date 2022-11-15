namespace TowerDefense
{
    public class PatrolArrivalNextPositionArgs
    {
        public int Id { get; private set; }

        public PatrolArrivalNextPositionArgs(int pId)
        {
            Id = pId;
        }
    }
}