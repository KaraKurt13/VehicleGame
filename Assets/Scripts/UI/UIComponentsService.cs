using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public interface IUIComponentsService : IService
    {
        void DrawTapWaitingScreen();
        void HideTapWaitingScreen();
        
    }

    public class UIComponentsService : MonoBehaviour, IUIComponentsService
    {
        [SerializeField]
        private GameObject _tapWaitingScreen;

        public void DrawTapWaitingScreen()
        {
            _tapWaitingScreen.SetActive(true);
        }

        public void HideTapWaitingScreen()
        {
            _tapWaitingScreen.SetActive(false);
        }
    }
}