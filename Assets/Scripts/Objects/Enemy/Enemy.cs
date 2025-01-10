using Assets.Scripts.Object.Infrastructure;
using Assets.Scripts.Objects.Enemies.Infranstructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        public float HealthPoints { get; private set; } = 10f;

        private EnemyStateMachine _stateMachine;

        private void Start()
        {
            _stateMachine = new EnemyStateMachine(this);
        }

        public void TakeDamage(float damage)
        {
            HealthPoints -= damage;
            Debug.Log($"Damaged! {HealthPoints}");
            if (HealthPoints <= 0)
                Die();
        }

        private void Die()
        {
            Debug.Log("Enemy death");
            Destroy(gameObject);
        }

        private void Update()
        {
            _stateMachine.UpdateState();
        }

        private void FixedUpdate()
        {
            _stateMachine.UpdateStatePhysics();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Projectile"))
                TakeDamage(5);
            if (other.CompareTag("Player"))
                Debug.Log("PLAYER");
        }

        private void OnBecameInvisible()
        {
            this.enabled = false;
        }

        private void OnBecameVisible()
        {
            this.enabled = true;
        }
    }
}