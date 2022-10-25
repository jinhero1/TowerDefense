using Library;
using UniRx;

namespace TowerDefense
{
    public class TowerController : IService
    {
        private TowerPool pool = null;

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

        private void OnConfirmedTowerPosition(ConfirmedTowerPositionArgs pArgs)
        {
            RangeDefense unit = pool.Rent();
            unit.transform.position = pArgs.Position;
        }
    }
}