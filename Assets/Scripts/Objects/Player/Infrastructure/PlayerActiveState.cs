using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Player.Infrastructure
{
    public class PlayerActiveState : IPlayerState
    {
        private TurretHandler _turretHandler;

        private CarMovementHandler _carMovementHandler;

        public PlayerActiveState(TurretHandler turretHandler, CarMovementHandler carMovementHandler)
        {
            _turretHandler = turretHandler;
            _carMovementHandler = carMovementHandler;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Update()
        {
            // Move car
            // Detect turret movement
            // Detect fire
        }

        public void PhysicsUpdate()
        {
            _carMovementHandler.Tick();
            _turretHandler.Tick();
        }
    }
}