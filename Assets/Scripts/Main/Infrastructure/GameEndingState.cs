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

        public GameEndingState(AllServices services)
        {
            _playerControllerService = services.Single<IPlayerControllerService>();
            _uIComponentsService = services.Single<IUIComponentsService>();
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
        }
    }
}