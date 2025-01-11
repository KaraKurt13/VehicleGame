using Assets.Scripts.UI.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class EnemyPanelComponent : ComponentBase
    {
        [SerializeField]
        private Slider _healthBar;

        public void UpdateHealthBarValue(float value)
        {
            _healthBar.value = value;
        }
    }
}