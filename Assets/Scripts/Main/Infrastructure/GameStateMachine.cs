using Assets.Scripts.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main.Infrastructure
{
    public class GameStateMachine : BaseStateMachine<IGameState>
    {
        public GameStateMachine(AllServices services)
        {
            AddState(typeof(GameEnterState), new GameEnterState(services, this));
            AddState(typeof(GamePreparingState), new GamePreparingState(services, this));
            AddState(typeof(GameLoopState), new GameLoopState(services, this));
            AddState(typeof(GameEndingState), new GameEndingState());
            Enter<GameEnterState>();
        }
    }
}