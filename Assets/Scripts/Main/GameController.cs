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
        [SerializeField]
        private LevelData _levelData;

        private GameStateMachine _gameStateMachine;

        private AllServices _services;

        private void Update()
        {
            _gameStateMachine?.UpdateState();
        }

        private void FixedUpdate()
        {
            _gameStateMachine?.UpdateStatePhysics();
        }

        private void Awake()
        {
            RegisterServices();
            _playerControllerService.Init(_services);
            _levelGeneratorService.Init(_levelData, _playerControllerService.Stats);
            _uIComponentsService.Init(_playerControllerService.Stats);
            _gameStateMachine = new GameStateMachine(_services, this);
        }

        public void ResetGame()
        {
            _playerControllerService.ResetPlayer();
            _uIComponentsService.ResetUI();
            _cameraService.ChangeCameraState(CameraStateEnum.SideView, true);
            _levelGeneratorService.ResetLevel();
            _gameStateMachine.Enter<GamePreparingState>();
        }

        #region Services
        [SerializeField]
        private CameraService _cameraService;
        [SerializeField]
        private LevelGeneratorService _levelGeneratorService;
        [SerializeField]
        private UIComponentsService _uIComponentsService;
        [SerializeField]
        private PlayerControllerService _playerControllerService;

        private void RegisterServices()
        {
            _services = AllServices.Container;
            RegisterInputService();
            RegisterCameraService();
            RegisterLevelGeneratorService();
            RegisterUIComponentsService();
            RegisterPlayerControllerService();
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
            _services.RegisterSingle<IUIComponentsService>(_uIComponentsService);
        }

        private void RegisterPlayerControllerService()
        {
            _services.RegisterSingle<IPlayerControllerService>(_playerControllerService);
        }
        #endregion Services
    }
}
