namespace TowerDefense
{
    public class EnemyPool : BasePool<Patrol>
    {
        private EnemyConfiguration configuration;

        public EnemyPool(EnemyConfiguration pConfiguration) : base(pConfiguration.Prefab)
        {
            configuration = pConfiguration;
        }

        protected override void OnCreatedInstance(Patrol pInstance)
        {
            pInstance.SetData(configuration);
        }
    }
}