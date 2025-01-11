using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

namespace Assets.Scripts.Objects.Player
{
    public class PlayerStats
    {
        public float MaxHealth { get; }

        public float HealthPoints { get; set; }

        public float NormalizedHealth
        {
            get
            {
                return (HealthPoints / MaxHealth);
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
                return Transform.position;
            }
        }

        public float TurretDamage { get; }

        public Transform Transform;

        public PlayerStats(float maxHealth, float turretDamage, Transform carTransform)
        {
            MaxHealth = maxHealth;
            HealthPoints = MaxHealth;
            TurretDamage = turretDamage;
            Transform = carTransform;
            StartPoint = Transform.position;
        }
    }
}