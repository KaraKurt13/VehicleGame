using Assets.Scripts.Objects.Player;
using Assets.Scripts.UI.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PlayerPanelComponent : ComponentBase
    {
        private PlayerStats _stats;

        public void Init(PlayerStats stats)
        {
            _stats = stats;
        }
    }
}