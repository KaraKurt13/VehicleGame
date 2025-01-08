using Assets.Scripts.Infrastructure;
using Assets.Scripts.Main.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameEnterState : IGameState
    {

        private GameStateMachine _gameStateMachine;

        private ILevelGeneratorService _levelGenerator;
        private ICameraService _cameraService;

        public GameEnterState(AllServices services, GameStateMachine stateMachine)
        {
            _gameStateMachine = stateMachine;
            _levelGenerator = services.Single<ILevelGeneratorService>();
            _cameraService = services.Single<ICameraService>();
        }

        public void Enter()
        {
            _levelGenerator.GenerateLevel();
            // Setting camera on side view
            _gameStateMachine.Enter<GamePreparingState>();
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }

        public void PhysicsUpdate()
        {
        }
    }
}