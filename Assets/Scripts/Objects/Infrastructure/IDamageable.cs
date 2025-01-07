using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object.Infrastructure
{
    public interface IDamageable
    {
        public void TakeDamage(float damage);
    }
}