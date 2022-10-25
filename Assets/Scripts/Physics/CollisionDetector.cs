using UnityEngine;

namespace TowerDefense
{
    public class CollisionDetector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D pOther)
        {
            Debug.Log($"{pOther.name} OnTriggerEnter2D: {pOther.tag}");
        }

        private void OnTriggerExit2D(Collider2D pOther)
        {
            Debug.Log($"{pOther.name} OnTriggerExit2D: {pOther.tag}");
        }
    }
}