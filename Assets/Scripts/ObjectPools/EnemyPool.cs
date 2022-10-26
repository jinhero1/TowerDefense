namespace TowerDefense
{
    public class EnemyPool : BasePool<Patrol>
    {
        public EnemyConfiguration Configuration { get; private set; }

        public EnemyPool(EnemyConfiguration pConfiguration) : base(pConfiguration.Prefab)
        {
            Configuration = pConfiguration;
        }

        protected override void OnCreatedInstance(Patrol pInstance)
        {
        }
    }
}