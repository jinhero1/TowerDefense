using UnityEngine;

namespace Library
{
    public class ApplicationUtility
    {
        public static void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();            
#endif
        }
    }
}