using Assets.Scripts.Infrastructure;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GamePreparingState : IGameState
    {
        private IInputService _inputService;

        private IUIComponentsService _uiComponentsService;

        private GameStateMachine _gameStateMachine;

        public GamePreparingState(AllServices services, GameStateMachine stateMachine)
        {
            _inputService = services.Single<IInputService>();
            _gameStateMachine = stateMachine;
        }

        public void Enter()
        {
            // Display waiting for start tap interface
        }

        public void Exit()
        {
            // activate player
            // hide preparing UI
            // change camera
        }

        public void Update()
        {
            if (_inputService.IsTouch())
                StartGame();
        }

        private void StartGame()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}