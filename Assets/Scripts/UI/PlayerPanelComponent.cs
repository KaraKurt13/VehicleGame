using Assets.Scripts.Objects.Player;
using Assets.Scripts.UI.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PlayerPanelComponent : ComponentBase
    {
        private PlayerStats _stats;

        [SerializeField]
        private Slider _playerHP, _playerProgress;

        public void Init(PlayerStats stats)
        {
            _stats = stats;
        }

        private void Update()
        {
            Debug.Log(_stats.NormalizedProgress);
            _playerHP.value = _stats.NormalizedHealth;
            _playerProgress.value = _stats.NormalizedProgress;
        }
    }
}