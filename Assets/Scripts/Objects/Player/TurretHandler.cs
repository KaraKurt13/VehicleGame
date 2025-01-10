using Assets.Scripts.Helpers;
using Assets.Scripts.Infrastructure;
using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Player
{
    public class TurretHandler : MonoBehaviour
    {
        private IInputService _input;

        private int _fireInterval, _ticksTillFire;

        private float _rotationClamp = 30f, _rotationSpeed;

        private float _targetRotation;

        public void Init(AllServices services)
        {
            _input = services.Single<IInputService>();
            _rotationSpeed = 60f / TimeHelper.TicksPerSecond;
            _fireInterval = TimeHelper.SecondsToTicks(1);
            _ticksTillFire = _fireInterval;
        }

        public void Tick()
        {
            UpdateRotation();
            FireTick();
        }

        private void UpdateRotation()
        {
            if (_input.IsTouchHeld())
            {
                var touchPositionX = _input.GetTouchPosition().x;
                var normalizedHorizontalInput = Mathf.InverseLerp(0, Screen.width, touchPositionX) * 2 - 1;
                _targetRotation = normalizedHorizontalInput * _rotationClamp;
            }

            Rotate();
        }

        private void Rotate()
        {
            var currentAngle = transform.localEulerAngles.y - 180;
            var newAngle = Mathf.MoveTowards(currentAngle, _targetRotation, _rotationSpeed);
            transform.localRotation = Quaternion.Euler(-90f, -180f, newAngle);
        }

        private void FireTick()
        {
            _ticksTillFire--;
            if (_ticksTillFire <= 0)
            {
                Fire();
                _ticksTillFire = _fireInterval;
            }
        }

        [SerializeField]
        private GameObject _projectilePrefab;

        [SerializeField]
        private Transform _projectilesSpawnPoint, _projectilesContainer;

        private void Fire()
        {
            var projectile = Instantiate(_projectilePrefab, _projectilesSpawnPoint.transform.position, Quaternion.identity, _projectilesContainer)
                .GetComponent<Projectile>();
            var direction = (_projectilesSpawnPoint.transform.position - transform.position).normalized;
            projectile.Activate(direction);
        }
    }
}
