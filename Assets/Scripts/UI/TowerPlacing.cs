using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class TowerPlacing : MonoBehaviour
    {
        [SerializeField] private GameObject dummyPlacement;
        [SerializeField] private SpriteRenderer range;
        [SerializeField] private Color legalColor;
        [SerializeField] private Color illegalColor;

        private readonly Vector3 initialPosition = new Vector3(-1000, -1000, 0);

        private Vector3Int cellPosition;
        private Vector3 cellWorldPosition;

        private bool canPlace;

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

            GameServices.TowerController.SetRange(pArgs.TowerType, range.transform);
        }

        private void SetActive(bool pValue)
        {
            this.enabled = pValue;
            dummyPlacement.SetActive(pValue);

            if (pValue)
            {
                dummyPlacement.transform.position = initialPosition;
            }
        }

        private void Update()
        {
            if (!GameServices.InputController.IsReady()) return;

            cellPosition = GameServices.InputController.MouseToCell();
            cellWorldPosition = GameServices.GameMapManager.Tilemap.GetCellCenterWorld(cellPosition);
            dummyPlacement.transform.position = cellWorldPosition;

            canPlace = GameServices.TowerController.CanPlace(cellPosition);
            range.color = canPlace ? legalColor : illegalColor;

            if (!canPlace) return;

            if (GameServices.InputController.IsConfirmed())
            {
                TowerType towerType = TowerType.Basic;
                MessageBroker.Default.Publish(new ConfirmedTowerPositionArgs(towerType, cellPosition, cellWorldPosition));

                SetActive(false);
            }
        }
    }
}