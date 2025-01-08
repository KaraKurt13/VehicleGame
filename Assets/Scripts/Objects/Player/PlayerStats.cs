using System.Collections;
using System.Collections.Generic;
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

        public Vector3 EndingPoint { get; set; }

        public float TurretDamage { get; }

        public PlayerStats(int maxHealth, float turretDamage, Transform carTransform)
        {
            MaxHealth = maxHealth;
            HealthPoints = MaxHealth;
            TurretDamage = turretDamage;
        }
    }
}