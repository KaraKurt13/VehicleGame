using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Enemies.Infranstructure
{
    public class EnemyIdleState : IEnemyState
    {
        private Enemy _enemy;
        public EnemyIdleState(Enemy enemy)
        {
            _enemy = enemy;
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
            _enemy.IsMoving = false;
        }
    }
}