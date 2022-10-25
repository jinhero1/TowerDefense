namespace TowerDefense
{
    public class SelectedTowerItemArgs
    {
        public TowerType TowerType { get; private set; }

        public SelectedTowerItemArgs(TowerType pTowerType)
        {
            TowerType = pTowerType;
        }
    }
}