using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class TowerCell : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Awake()
        {
            button.OnClickAsObservable().Subscribe(_ =>
            {
                MessageBroker.Default.Publish(new SelectedTowerItemArgs());
            });
        }
    }
}