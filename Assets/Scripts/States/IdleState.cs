using UnityEngine;

namespace TowerDefense
{
    public class IdleState : BaseState
    {
        [SerializeField] private WaveSpawner waveSpawner;

        public override void OnEnter()
        {
            waveSpawner.NextWave();
        }
    }
}