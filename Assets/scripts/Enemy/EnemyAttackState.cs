using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private float attackTimer;

    public EnemyAttackState(
        EnemyStateMachine stateMachine,
        EnemyController enemy)
        : base(stateMachine, enemy)
    {
    }

    public override void Enter()
    {
        Debug.Log(enemy.Data.enemyName + " → ATTACK");

        attackTimer = 0f;

        enemy.PlayAnimation("Punching");
    }

    public override void Update()
    {
        if (enemy.Player == null)
            return;

        float distance = enemy.DistanceToPlayer();

        if (distance > enemy.Data.attackRange)
        {
            stateMachine.ChangeState(
                new EnemyChaseState(stateMachine, enemy)
            );

            return;
        }

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            GameManager.Instance.TakeDamage(10);

            Debug.Log(
                enemy.Data.enemyName +
                " attacks the player for 10 damage!"
            );

            enemy.PlayAnimation("Punching");

            attackTimer = 1.5f;
        }
    }
}