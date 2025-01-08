using Assets.Scripts.Infrastructure;
using Assets.Scripts.Main;
using Assets.Scripts.Objects.Player.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Player
{
    public interface IPlayerControllerService : IService 
    {
        PlayerStats Stats { get; set; }

        void Activate();

        void Deactivate();

        bool HasPlayerWon();

        bool HasPlayerLost();
    }

    public class PlayerControllerService : MonoBehaviour, IPlayerControllerService
    {
        public PlayerStats Stats { get; set; }

        private PlayerStateMachine _playerStateMachine;

        [SerializeField]
        private TurretHandler _turretHandler;

        [SerializeField]
        private CarMovementHandler _carMovementHandler;

        private void Update()
        {
            _playerStateMachine?.UpdateState();
        }

        private void FixedUpdate()
        {
            _playerStateMachine?.UpdateStatePhysics();
        }

        public void Init(AllServices _services)
        {
            Stats = new PlayerStats(100, 10f, _carMovementHandler.Transform);
            _playerStateMachine = new PlayerStateMachine();
            _playerStateMachine.AddState(typeof(PlayerIdleState), new PlayerIdleState());
            _playerStateMachine.AddState(typeof(PlayerActiveState), new PlayerActiveState(_turretHandler, _carMovementHandler));
            _playerStateMachine.Enter<PlayerIdleState>();
        }

        public void Activate()
        {
            _playerStateMachine.Enter<PlayerActiveState>();
        }

        public void Deactivate()
        {
            _playerStateMachine.Enter<PlayerIdleState>();
        }

        public bool HasPlayerWon()
        {
            return _carMovementHandler.Transform.position.z >= Stats.EndingPoint.z;
        }

        public bool HasPlayerLost()
        {
            return Stats.HealthPoints <= 0;
        }
    }
}