using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Player
{
    public class CarMovementHandler : MonoBehaviour
    {
        public Transform Transform => transform;

        private float _moveSpeed;

        private bool _isMovingSideways = false;

        private float _maxTicksForSideMove, _ticksForSideMove;

        private float _timeElapsed, _moveDuration = 3f, _startX, _targetX = 0f;

        private const float _minTargetX = -2.5f, _maxTargetX = 2.5f;

        private void Start()
        {
            _moveSpeed = 5f / TimeHelper.TicksPerSecond;
            _maxTicksForSideMove = TimeHelper.SecondsToTicks(3);
            _ticksForSideMove = _maxTicksForSideMove;
        }

        public void Tick()
        {
            if (!_isMovingSideways)
            {
                _ticksForSideMove--;
                if (_ticksForSideMove <= 0)
                {
                    _isMovingSideways = true;
                    _timeElapsed = 0f;
                    _startX = Transform.position.x;
                    _targetX = Random.Range(_minTargetX, _maxTargetX);
                }
            }

            Move();
        }

        public void ResetCar(Vector3 startPos)
        {
            transform.position = startPos;
            _targetX = 0f;
            _ticksForSideMove = _maxTicksForSideMove;
            _isMovingSideways = false;
        }

        private void Move()
        {
            var pos = Transform.position;
            pos.z += _moveSpeed;

            if (_isMovingSideways)
            {
                _timeElapsed += Time.fixedDeltaTime;
                var t = Mathf.Clamp01(_timeElapsed / _moveDuration);
                var sinValue = Mathf.Sin(t * Mathf.PI * 0.5f);

                pos.x = Mathf.Lerp(_startX, _targetX, sinValue);

                if (t >= 1f)
                {
                    _isMovingSideways = false;
                    _ticksForSideMove = _maxTicksForSideMove;
                }
            }

            Transform.position = pos;
        }
    }
}
