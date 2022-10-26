using Library;
using UniRx;

namespace TowerDefense
{
    public class CombatController : IService
    {
        public void Initialize()
        {
            MessageBroker.Default.Receive<CombatArgs>().Subscribe(OnCombat);
            MessageBroker.Default.Receive<GameResultArgs>().Subscribe(_ =>
            {
                GameServices.GameDataManager.StopFire();
            });
        }

        private void OnCombat(CombatArgs pArgs)
        {
            UnityEngine.Debug.Log($"{pArgs.Tower} attack {pArgs.Enemy}");
        }
    }
}