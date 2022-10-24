using UnityEngine;

namespace Library
{
    public class TimeUtility
    {
        private const int ZERO = 0;
        private const int ONE = 1;

        public static void Pause()
        {
            Time.timeScale = ZERO;
        }

        public static void Resume()
        {
            Time.timeScale = ONE;
        }
    }
}