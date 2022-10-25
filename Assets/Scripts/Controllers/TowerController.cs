using Library;
using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class TowerController : IService
    {
        private TowerPool pool = null;

        private bool _isInPlaceableRange;
        private bool _isInOccupying;

        public void Initialize()
        {
            MessageBroker.Default.Receive<ConfirmedTowerPositionArgs>().Subscribe(OnConfirmedTowerPosition);
        }

        public void Prepare()
        {
            int typeIndex = (int)TowerType.Basic;
            TowerConfiguration configuration = GameServices.GameAssetManager.TowerConfigurations.GetConfiguration(typeIndex);
            pool = new TowerPool(configuration);
        }

        public void Reset()
        {
            pool.ReturnAll();
        }

        public bool CanPlace(Vector3Int pCellPosition)
        {
            _isInPlaceableRange = GameServices.GameAssetManager.MapConfiguration.IsInPlaceableRange(pCellPosition);
            _isInOccupying = GameServices.GameDataManager.IsInOccupying(pCellPosition);

            return _isInPlaceableRange && !_isInOccupying;
        }

        private void OnConfirmedTowerPosition(ConfirmedTowerPositionArgs pArgs)
        {
            RangeDefense unit = pool.Rent();
            unit.transform.position = pArgs.CellWorldPosition;

            GameServices.GameDataManager.Occupy(pArgs.CellPosition);
        }
    }
}