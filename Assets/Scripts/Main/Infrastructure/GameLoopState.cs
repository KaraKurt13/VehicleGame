using Assets.Scripts.Infrastructure;
using Assets.Scripts.Objects.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameLoopState : IGameState
    {
        private IPlayerControllerService _playerControllerService;

        private GameStateMachine _gameStateMachine;

        private GameController _gameController;

        public GameLoopState(AllServices services, GameStateMachine stateMachine, GameController gameController)
        {
            _playerControllerService = services.Single<IPlayerControllerService>();
            _gameStateMachine = stateMachine;
            _gameController = gameController;
        }

        public void Enter()
        {
            _playerControllerService.Activate();
            // After player tap start car moving, activate turret shot
            // If player dies, show losing screen
        }

        public void Exit()
        {
            _playerControllerService.Deactivate();
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