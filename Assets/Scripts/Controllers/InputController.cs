using Library;
using UniRx;
using UnityEngine;

namespace TowerDefense
{
    public class InputController : IService
    {
        private Camera mainCamera;
        private float distance;

        public void Initialize()
        {
            MessageBroker.Default.Receive<GameAssetReadyArgs>().Subscribe(_ => OnGameAssetReady());
        }

        private void OnGameAssetReady()
        {
            mainCamera = Camera.main;
            distance = GameServices.GameMapManager.Tilemap.transform.position.z - Camera.main.transform.position.z;
        }

        public bool IsReady()
        {
            return mainCamera != null;
        }

        public bool IsConfirmed()
        {
            return Input.GetMouseButtonDown(0);
        }

        public Vector3Int MouseToCell()
        {
            return GameServices.GameMapManager.Tilemap.WorldToCell(GetMouseWorldPosition());
        }

        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = distance;
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

            return mousePosition;
        }
    }
}