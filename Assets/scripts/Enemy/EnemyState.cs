public abstract class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected EnemyController enemy;

    public EnemyState(
        EnemyStateMachine stateMachine,
        EnemyController enemy)
    {
        this.stateMachine = stateMachine;
        this.enemy = enemy;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }
}