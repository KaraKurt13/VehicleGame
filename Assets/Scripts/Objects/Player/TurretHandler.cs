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

        public void Init(AllServices services)
        {
            _input = services.Single<IInputService>();
        }

        public void Tick()
        {
            UpdateRotation();
            FireTick();
        }

        private float _rotationClamp = 30f, _rotationSpeed = 1f;
        private float _targetRotation;

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

        }
    }
}
