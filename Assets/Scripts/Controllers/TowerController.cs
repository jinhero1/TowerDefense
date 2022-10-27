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
            pool = new TowerPool(GameServices.GameAssetManager.TowerConfigurations.Prefab);
        }

        public void Reset()
        {
            pool.ReturnAll();
        }

        public void ChangeTower(TowerType pType, SpriteRenderer pSpriteRenderer, Transform pRangeTransform)
        {
            TowerConfiguration configuration = GameServices.GameAssetManager.TowerConfigurations.GetConfiguration(pType);

            pSpriteRenderer.sprite = configuration.Image;
            pRangeTransform.localScale = new Vector3(configuration.Range, configuration.Range, pRangeTransform.localScale.z);
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

            GameServices.GameDataManager.AddOccupying(pArgs.CellPosition);
        }
    }
}