using Assets.Scripts.Infrastructure;
using Assets.Scripts.Object.Infrastructure;
using Assets.Scripts.Objects.Enemies.Infranstructure;
using Assets.Scripts.Objects.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Enemies
{
    public class Enemy : MonoBehaviour
    {
        public float HealthPoints { get; private set; } = 10f;

        public bool AttackIsReady { get; private set; } = true;

        public Animator Animator;

        public bool IsMoving = false;

        private IPlayerControllerService _playerControllerService;

        [SerializeField]
        private BoxCollider _damageTrigger;

        [SerializeField]
        private SphereCollider _detectionTrigger;

        [SerializeField]
        private Rigidbody _rigidBody;

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
        }

        private EnemyStateMachine _stateMachine;

        private Vector3 _initialPosition;

        private void Awake()
        {
            _playerControllerService = AllServices.Container.Single<IPlayerControllerService>();
            _stateMachine = new EnemyStateMachine(this, _playerControllerService.Stats);
            _initialPosition = transform.position;
        }

        public void Move(Vector3 pos, Quaternion rotation)
        {
            IsMoving = true;
            transform.SetPositionAndRotation(pos, rotation);
        }

        public void TakeDamage(float damage)
        {
            HealthPoints -= damage;
            if (HealthPoints <= 0)
                _stateMachine.Enter<EnemyDyingState>();
        }

        public void DisableTriggers()
        {
            _damageTrigger.enabled = false;
            _detectionTrigger.enabled = false;
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }

        public void ResetEnemy()
        {
            transform.position = _initialPosition;
            transform.rotation = Quaternion.identity;
            _stateMachine.Enter<EnemyIdleState>();
            IsMoving = false;
            gameObject.SetActive(true);
        }

        private void Update()
        {
            Animator.SetBool("IsMoving", IsMoving);
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
            if (other.CompareTag("Player") && other.gameObject.layer == LayerMask.NameToLayer("DetectionTrigger"))
                _stateMachine.Enter<EnemyChasingState>();

            if (other.CompareTag("Player") && other.gameObject.layer == LayerMask.NameToLayer("DamageTrigger"))
                AttackPlayer();
                
        }

        private float _damage = 5;

        private void AttackPlayer()
        {
            _playerControllerService.TakeDamage(_damage);
            _stateMachine.Enter<EnemyDyingState>();
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