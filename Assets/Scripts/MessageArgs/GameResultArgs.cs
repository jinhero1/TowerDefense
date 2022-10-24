namespace TowerDefense
{
    public class GameResultArgs
    {
        public bool IsWin { get; private set; }

        public GameResultArgs(bool pIsWin)
        {
            IsWin = pIsWin;
        }
    }
}