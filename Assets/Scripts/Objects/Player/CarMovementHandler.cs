using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Player
{
    public class CarMovementHandler : MonoBehaviour
    {
        private float _moveStep;

        private void Start()
        {
            _moveStep = 4f / TimeHelper.TicksPerSecond;
        }

        public void Move()
        {
            var pos = transform.position;
            pos.z += _moveStep;
            transform.position = pos;
        }

        private const float _minTargetX = -2.5f, _maxTargetX = 2.5f;

        private float _targetX;

        private void LerpSideMove()
        {

        }
    }
}
