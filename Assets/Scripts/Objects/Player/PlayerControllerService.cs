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
            Debug.Log(_playerStateMachine.CurrentState);
            _playerStateMachine?.Update();
        }

        public void Init(AllServices _services)
        {
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
    }
}