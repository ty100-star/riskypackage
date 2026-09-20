using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(
        EnemyStateMachine stateMachine,
        EnemyController enemy)
        : base(stateMachine, enemy)
    {
    }

    public override void Enter()
    {
        Debug.Log(enemy.Data.enemyName + " → CHASE");
{
    Debug.Log(enemy.Data.enemyName + " → CHASE");
    enemy.PlayAnimation("Run Fast");
}
    }

    public override void Update()
    {
        if (enemy.Player == null)
            return;

        float distance = enemy.DistanceToPlayer();

        // Close enough to attack.
        if (distance <= enemy.Data.attackRange)
        {
            stateMachine.ChangeState(
                new EnemyAttackState(stateMachine, enemy)
            );

            return;
        }

        // Player escaped.
        if (distance > enemy.Data.detectionRange)
        {
            stateMachine.ChangeState(
                new EnemyPatrolState(stateMachine, enemy)
            );

            return;
        }

        enemy.MoveTowards(
            enemy.Player.position,
            enemy.Data.chaseSpeed
        );
    }
}