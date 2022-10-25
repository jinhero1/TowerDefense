using Library;
namespace TowerDefense
{
    public class TowerPool : BasePool<RangeDefense>
    {
        private TowerConfiguration configuration;

        public TowerPool(TowerConfiguration pConfiguration) : base(pConfiguration.Prefab)
        {
            configuration = pConfiguration;
        }

        protected override void OnCreatedInstance(RangeDefense pInstance)
        {
        }
    }
}