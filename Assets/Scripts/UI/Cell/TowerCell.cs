using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class TowerCell : MonoBehaviour
    {
        [SerializeField] private TowerType towerType;
        [SerializeField] private Button button;
        [SerializeField] private Image image;

        private void Awake()
        {
            MessageBroker.Default.Receive<GameAssetReadyArgs>().Subscribe(_ =>
            {
                TowerConfiguration configuration = GameServices.GameAssetManager.TowerConfigurations.GetConfiguration(towerType);
                image.sprite = configuration.Icon;
            });
            button.OnClickAsObservable().Subscribe(_ =>
            {
                MessageBroker.Default.Publish(new SelectedTowerItemArgs(towerType));
            });
        }
    }
}