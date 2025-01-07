using Assets.Scripts.Infrastructure;
using Assets.Scripts.Main.Infrastructure;
using Assets.Scripts.Objects.Player;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameController : MonoBehaviour
    {
        public PlayerController PlayerController;

        private GameStateMachine _gameStateMachine;

        private AllServices _services;

        private void Awake()
        {
            RegisterServices();
            _gameStateMachine = new GameStateMachine(_services);
        }

        #region Services
        [SerializeField]
        private CameraService _cameraService;
        [SerializeField]
        private LevelGeneratorService _levelGeneratorService;
        [SerializeField]
        private UIComponentsService _UIComponentsService;

        private void RegisterServices()
        {
            _services = AllServices.Container;
            RegisterInputService();
            RegisterCameraService();
            RegisterLevelGeneratorService();
            RegisterUIComponentsService();
        }

        private void RegisterInputService()
        {
            _services.RegisterSingle<IInputService>(new MobileInputService());
        }

        private void RegisterCameraService()
        {
            _services.RegisterSingle<ICameraService>(_cameraService);
        }

        private void RegisterLevelGeneratorService()
        {
            _services.RegisterSingle<ILevelGeneratorService>(_levelGeneratorService);
        }

        private void RegisterUIComponentsService()
        {
            _services.RegisterSingle<IUIComponentsService>(_UIComponentsService);
        }
        #endregion Services
    }
}
