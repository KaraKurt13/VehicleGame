using Assets.Scripts.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float _speedPerSecond;

        private float _speedPerTick;

        private Vector3 _direction;

        public void Activate(Vector3 direction)
        {
            _speedPerTick = _speedPerSecond / TimeHelper.TicksPerSecond;
            _direction = direction;
            _direction.y = 0;
        }

        private void FixedUpdate()
        {
            Debug.Log(_direction);
            transform.position += _direction * _speedPerTick;
        }

        private void OnBecameInvisible()
        {
            //Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Enemy>(out var enemy))
            {

            }
        }
    }
}