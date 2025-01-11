using Assets.Scripts.Main.Infrastructure;
using Assets.Scripts.Objects.Player;
using UnityEngine;

namespace Assets.Scripts.Objects.Enemies.Infranstructure 
{
    public class EnemyStateMachine : BaseStateMachine<IEnemyState>
    {
        public EnemyStateMachine(Enemy enemy, PlayerStats player)
        {
            AddState(typeof(EnemyIdleState), new EnemyIdleState(enemy));
            AddState(typeof(EnemyChasingState), new EnemyChasingState(enemy, player));
            AddState(typeof(EnemyDyingState), new EnemyDyingState(enemy));
            Enter<EnemyIdleState>();
        }
    }
}
