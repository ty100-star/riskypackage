using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    private int currentPatrolPoint = 0;

    public EnemyPatrolState(
        EnemyStateMachine stateMachine,
        EnemyController enemy)
        : base(stateMachine, enemy)
    {
    }

    public override void Enter()
    {
        Debug.Log(enemy.Data.enemyName + " → PATROL");
{
    Debug.Log(enemy.Data.enemyName + " → PATROL");
    enemy.PlayAnimation("Walk");
}
    }

    public override void Update()
    {
        // Check whether the player is close enough to chase.
        if (enemy.Player != null &&
            enemy.DistanceToPlayer() <= enemy.Data.detectionRange)
        {
            stateMachine.ChangeState(
                new EnemyChaseState(stateMachine, enemy)
            );

            return;
        }

        // If there are no patrol points, stay here.
        if (enemy.PatrolPoints == null ||
            enemy.PatrolPoints.Length == 0)
        {
            return;
        }

        Transform target =
            enemy.PatrolPoints[currentPatrolPoint];

        enemy.MoveTowards(
            target.position,
            enemy.Data.moveSpeed
        );

        if (Vector3.Distance(
            enemy.transform.position,
            target.position) < 0.5f)
        {
            currentPatrolPoint++;

            if (currentPatrolPoint >= enemy.PatrolPoints.Length)
            {
                currentPatrolPoint = 0;
            }
        }
    }
}