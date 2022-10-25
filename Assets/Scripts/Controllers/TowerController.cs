using Library;
using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class TowerController : IService
    {
        private TowerPool pool = null;

        private int _range;
        private bool _isInPlaceableRange;
        private bool _isInOccupying;

        public void Initialize()
        {
            MessageBroker.Default.Receive<ConfirmedTowerPositionArgs>().Subscribe(OnConfirmedTowerPosition);
        }

        public void Prepare()
        {
            TowerType type = TowerType.Basic;
            TowerConfiguration configuration = GameServices.GameAssetManager.TowerConfigurations.GetConfiguration(type);
            pool = new TowerPool(configuration);
        }

        public void Reset()
        {
            pool.ReturnAll();
        }

        public void SetRange(TowerType pType, Transform pTarget)
        {
            _range = GameServices.GameAssetManager.TowerConfigurations.GetRange(pType);
            pTarget.localScale = new Vector3(_range, _range, pTarget.localScale.z);
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
            unit.SetData(GameServices.GameAssetManager.TowerConfigurations.GetConfiguration(pArgs.TowerType));
            unit.transform.position = pArgs.CellWorldPosition;

            GameServices.GameDataManager.Occupy(pArgs.CellPosition);
        }
    }
}