using Assets.Scripts.Infrastructure;
using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private TurretHandler _turretHandler;

        private IInputService _inputService;

        private bool _isActive = false;

        private void Update()
        {
            
        }

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Activate()
        {

        }
    }
}