using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Enemies.Infranstructure
{
    public class EnemyDyingState : IEnemyState
    {
        private Enemy _enemy;

        public EnemyDyingState(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void Enter()
        {
            _enemy.DisableTriggers();
        }

        public void Exit()
        {
        }

        public void PhysicsUpdate()
        {
            TicksTillDeath--;

            if (TicksTillDeath <= 0)
                _enemy.Die();
               
        }

        private int TicksTillDeath;

        public void Update()
        {
        }
    }
}