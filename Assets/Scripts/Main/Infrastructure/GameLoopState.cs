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

        public GameLoopState(AllServices services, GameStateMachine stateMachine)
        {
            _playerControllerService = services.Single<IPlayerControllerService>();
            _gameStateMachine = stateMachine;
        }

        public void Enter()
        {
            _playerControllerService.Activate();
            // After player tap start car moving, activate turret shot
            // On reaching the end, show win screen
            // If player dies, show losing screen
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}