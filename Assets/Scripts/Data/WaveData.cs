using UniRx;

namespace TowerDefense
{
    public class WaveData
    {
        private const int ONE = 1;

        public IReactiveProperty<int> Current { get; private set; }
        public IReactiveProperty<int> Max { get; private set; }

        public WaveData(int pMaxWave)
        {
            Current = new ReactiveProperty<int>(ONE);
            Max = new ReactiveProperty<int>(pMaxWave);
        }

        public bool IsOverMax()
        {
            return Current.Value > Max.Value;
        }
    }
}