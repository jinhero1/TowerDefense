namespace TowerDefense
{
    public class NextWaveArgs
    {
        public bool IsOverMax { get; private set; }

        public NextWaveArgs(bool pIsOverMax)
        {
            IsOverMax = pIsOverMax;
        }
    }
}