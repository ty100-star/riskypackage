using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyState CurrentState { get; private set; }

    private EnemyController enemy;

    public void Initialize(EnemyController enemyController)
    {
        enemy = enemyController;

        ChangeState(new EnemyPatrolState(this, enemy));
    }

    private void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    public void ChangeState(EnemyState newState)
    {
        if (newState == null)
            return;

        CurrentState?.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }
}