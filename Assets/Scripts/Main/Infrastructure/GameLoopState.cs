using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameLoopState : IGameState
    {
        public GameLoopState()
        {

        }

        public void Enter()
        {
            // Waiting for player tap
            // After player tap start car moving, activate turret shot
            // On reaching the end, show win screen
            // If player dies, show losing screen
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}