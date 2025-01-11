using Assets.Scripts.Main;
using Assets.Scripts.UI.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameResultsComponent : ComponentBase
    {
        [SerializeField]
        private GameObject _winScreen, _loseScreen;

        public void DrawResults(GameResultEnum result)
        {
            switch (result)
            {
                case GameResultEnum.Win:
                    _winScreen.SetActive(true);
                    break;
                case GameResultEnum.Lose:
                    _loseScreen.SetActive(true);
                    break;
            }

            Draw();
        }

        public override void Hide()
        {
            _winScreen.SetActive(false);
            _loseScreen.SetActive(false);
            base.Hide();
        }
    }
}