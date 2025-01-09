using Assets.Scripts.Infrastructure;
using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Player
{
    public class TurretHandler : MonoBehaviour
    {
        private IInputService _input;

        public void Init(AllServices services)
        {
            _input = services.Single<IInputService>();
        }

        public void Tick()
        {
            UpdateRotation();
            FireTick();
        }

        private void UpdateRotation()
        {

        }

        private void FireTick()
        {

        }
    }
}
