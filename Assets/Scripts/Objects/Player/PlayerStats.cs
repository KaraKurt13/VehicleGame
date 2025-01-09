using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

namespace Assets.Scripts.Objects.Player
{
    public class PlayerStats
    {
        public int MaxHealth { get; }

        public int HealthPoints { get; set; }

        public float NormalizedHealth
        {
            get
            {
                return (MaxHealth / HealthPoints);
            }
        }

        public float NormalizedProgress
        {
            get
            {
                var playerDistance = CurrentPosition.z - StartPoint.z;
                return Mathf.Clamp01(playerDistance / TotalLevelDistance);
            }
        }

        public Vector3 EndingPoint { get; set; }

        public Vector3 StartPoint { get; }

        public float TotalLevelDistance { get; set; }

        public Vector3 CurrentPosition
        {
            get
            {
                return _carTransform.position;
            }
        }

        public float TurretDamage { get; }

        private Transform _carTransform;

        public PlayerStats(int maxHealth, float turretDamage, Transform carTransform)
        {
            MaxHealth = maxHealth;
            HealthPoints = MaxHealth;
            TurretDamage = turretDamage;
            _carTransform = carTransform;
            StartPoint = _carTransform.position;
        }
    }
}