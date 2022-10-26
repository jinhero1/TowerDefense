using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class GameHUD : MonoBehaviour
    {
        [SerializeField] private Text wave;
        [SerializeField] private Text hp;

        private int maxWave;
        private IDisposable waveDisposable;
        private IDisposable hpDisposable;

        private void Awake()
        {
            MessageBroker.Default.Receive<GameDataReadyArgs>().Subscribe(_ =>
            {
                waveDisposable?.Dispose();
                waveDisposable = GameServices.GameDataManager.WaveData.Current.Subscribe(x =>
                {
                    maxWave = GameServices.GameDataManager.WaveData.Max.Value;
                    int displayValue = x > maxWave ? maxWave : x;
                    wave.text = $"Wave: {displayValue}/{maxWave}";
                });

                hpDisposable?.Dispose();
                hpDisposable = GameServices.GameDataManager.PlayerData.HP.Subscribe(x =>
                {
                    int displayValue = x < 0 ? 0 : x;
                    hp.text = $"HP: {displayValue}";
                });
            });
        }
    }
}