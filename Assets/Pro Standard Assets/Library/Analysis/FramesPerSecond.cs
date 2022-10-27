using UnityEngine;
using UnityEngine.UI;

namespace Library
{
    public class FramesPerSecond : MonoBehaviour
    {
        private const int ZERO = 0;
        private const int INTERVAL_TIME = 1;

        [SerializeField] private Text text;

        private int frames;
        private float timer;

        void Update()
        {
            if (timer >= INTERVAL_TIME)
            {
                text.text = frames.ToString();
                frames = ZERO;
                timer -= INTERVAL_TIME;
            }

            frames++;
            timer += Time.deltaTime;
        }
    }
}