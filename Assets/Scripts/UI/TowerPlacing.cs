using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class TowerPlacing : MonoBehaviour
    {
        [SerializeField] private GameObject dummyPlacement;

        private Vector3Int cellPosition;
        private Vector3 cellWorldPosition;

        private void Awake()
        {
            MessageBroker.Default.Receive<SelectedTowerItemArgs>().Subscribe(OnSelectedTowerItem);
            MessageBroker.Default.Receive<GameResultArgs>().Subscribe(_ =>
            {
                SetActive(false);
            });
        }

        private void OnSelectedTowerItem(SelectedTowerItemArgs pArgs)
        {
            SetActive(true);
        }

        private void SetActive(bool pValue)
        {
            this.enabled = pValue;
            dummyPlacement.SetActive(pValue);
        }

        private void Update()
        {
            if (!GameServices.InputController.IsReady()) return;

            cellPosition = GameServices.InputController.MouseToCell();
            cellWorldPosition = GameServices.GameMapManager.Tilemap.GetCellCenterWorld(cellPosition);
            dummyPlacement.transform.position = cellWorldPosition;

            if (GameServices.InputController.IsConfirmed())
            {
                TowerType towerType = TowerType.Basic;
                MessageBroker.Default.Publish(new ConfirmedTowerPositionArgs(towerType, cellWorldPosition));

                SetActive(false);
            }
        }
    }
}