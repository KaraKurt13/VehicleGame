using Assets.Scripts.Infrastructure;
using Assets.Scripts.Objects.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameController : MonoBehaviour
    {
        public LevelGenerator LevelGenerator;

        public PlayerController PlayerController;

        private AllServices _services;

        private void Awake()
        {
            RegisterServices();
        }

        private void Start()
        {
            var inputService = _services.Single<IInputService>();

            LevelGenerator.GenerateLevel();
            PlayerController.Init(inputService);
        }

        #region Services
        private void RegisterServices()
        {
            _services = AllServices.Container;
            RegisterInputService();
        }

        private void RegisterInputService()
        {
            _services.RegisterSingle<IInputService>(new MobileInputService());
        }
        #endregion Services
    }
}
