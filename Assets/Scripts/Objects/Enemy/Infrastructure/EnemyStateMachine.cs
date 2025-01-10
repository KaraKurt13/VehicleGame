using Assets.Scripts.Main.Infrastructure;

namespace Assets.Scripts.Objects.Enemies.Infranstructure 
{
    public class EnemyStateMachine : BaseStateMachine<IEnemyState>
    {
        public EnemyStateMachine(Enemy enemy)
        {
            AddState(typeof(EnemyIdleState), new EnemyIdleState());
            AddState(typeof(EnemyChasingState), new EnemyChasingState());
            AddState(typeof(EnemyDyingState), new EnemyDyingState());
            Enter<EnemyIdleState>();
        }
    }
}
