using Assets.Scripts.Infrastructure;
using Assets.Scripts.Main;
using Assets.Scripts.Objects.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public interface IUIComponentsService : IService
    {
        void DrawTapWaitingScreen();
        void HideTapWaitingScreen();
        void DrawPlayerPanel();
        void HidePlayerPanel();
        void DrawGameResults(GameResultEnum result);
    }

    public class UIComponentsService : MonoBehaviour, IUIComponentsService
    {
        [SerializeField]
        private GameObject _tapWaitingScreen;

        [SerializeField]
        private PlayerPanelComponent _playerPanel;

        [SerializeField]
        private GameResultsComponent _gameResults;

        public void DrawTapWaitingScreen()
        {
            _tapWaitingScreen.SetActive(true);
        }

        public void HideTapWaitingScreen()
        {
            _tapWaitingScreen.SetActive(false);
        }

        public void Init(PlayerStats stats)
        {
            _playerPanel.Init(stats);
        }

        public void DrawGameResults(GameResultEnum result)
        {
            _gameResults.DrawResults(result);
        }

        public void DrawPlayerPanel()
        {
            _playerPanel.Draw();
        }

        public void HidePlayerPanel()
        {
            _playerPanel.Hide();
        }
    }
}