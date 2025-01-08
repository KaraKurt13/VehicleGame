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
            _uiComponentsService = services.Single<IUIComponentsService>();
            _gameStateMachine = stateMachine;
        }

        private void StartGame()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Enter()
        {
            _uiComponentsService.DrawTapWaitingScreen();
        }

        public void Exit()
        {
            _uiComponentsService.HideTapWaitingScreen();
            // start camera changing coroutine camera
        }

        public void Update()
        {
            if (_inputService.IsTouch())
                StartGame();
        }

        public void PhysicsUpdate()
        {
        }

    }
}