using Assets.Scripts.Infrastructure;
using Assets.Scripts.Objects.Player;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameEndingState : IGameState
    {
        private IPlayerControllerService _playerControllerService;

        private IUIComponentsService _uIComponentsService;

        private IInputService _inputService;

        private GameController _gameController;

        public GameEndingState(AllServices services, GameController gameController)
        {
            _playerControllerService = services.Single<IPlayerControllerService>();
            _uIComponentsService = services.Single<IUIComponentsService>();
            _inputService = services.Single<IInputService>();
            _gameController = gameController;
        }

        public void Enter()
        {
            _uIComponentsService.HidePlayerPanel();
            var gameResult = _playerControllerService.HasPlayerWon() ? GameResultEnum.Win : GameResultEnum.Lose;
            _uIComponentsService.DrawGameResults(gameResult);
        }

        public void Exit()
        {
        }

        public void PhysicsUpdate()
        {
        }

        public void Update()
        {
            if (_inputService.IsTouch())
                _gameController.ResetGame();
        }
    }
}