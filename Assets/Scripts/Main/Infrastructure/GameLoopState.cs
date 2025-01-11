using Assets.Scripts.Infrastructure;
using Assets.Scripts.Objects.Player;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameLoopState : IGameState
    {
        private IPlayerControllerService _playerControllerService;

        private IUIComponentsService _uIComponentsService;

        private ICameraService _cameraService;

        private GameStateMachine _gameStateMachine;

        private GameController _gameController;

        public GameLoopState(AllServices services, GameStateMachine stateMachine, GameController gameController)
        {
            _playerControllerService = services.Single<IPlayerControllerService>();
            _uIComponentsService = services.Single<IUIComponentsService>();
            _cameraService = services.Single<ICameraService>();
            _gameStateMachine = stateMachine;
            _gameController = gameController;
        }

        public void Enter()
        {
            _cameraService.ChangeCameraState(CameraStateEnum.Following, false);
            _playerControllerService.Activate();
            _uIComponentsService.DrawPlayerPanel();
        }

        public void Exit()
        {
            _playerControllerService.Deactivate();
            _uIComponentsService.HidePlayerPanel();
        }

        public void Update()
        {
            if (_playerControllerService.HasPlayerWon() || _playerControllerService.HasPlayerLost())
                _gameStateMachine.Enter<GameEndingState>();
        }

        public void PhysicsUpdate()
        {
        }
    }
}