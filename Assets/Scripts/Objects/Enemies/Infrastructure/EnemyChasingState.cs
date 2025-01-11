using Assets.Scripts.Helpers;
using Assets.Scripts.Objects.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Enemies.Infranstructure
{
    public class EnemyChasingState : IEnemyState
    {
        private PlayerStats _player;

        private Enemy _enemy;

        private float _moveSpeed;

        public EnemyChasingState(Enemy enemy, PlayerStats playerStats)
        {
            _player = playerStats;
            _enemy = enemy;
            _moveSpeed = 0.5f / TimeHelper.TicksPerSecond;
        }
        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void PhysicsUpdate()
        {
        }

        public void Update()
        {
            var newPos = Vector3.MoveTowards(_enemy.Position, _player.CurrentPosition, _moveSpeed);
            _enemy.Move(newPos);
        }
    }
}