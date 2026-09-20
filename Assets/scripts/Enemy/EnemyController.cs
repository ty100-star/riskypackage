using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyData Data { get; private set; }
    public Transform Player { get; private set; }
    public Transform[] PatrolPoints { get; private set; }

    private EnemyStateMachine stateMachine;

    public void Initialize(
        EnemyData data,
        Transform player,
        Transform[] patrolPoints)
    {
        Data = data;
        Player = player;
        PatrolPoints = patrolPoints;

        stateMachine = GetComponent<EnemyStateMachine>();

        if (stateMachine == null)
        {
            Debug.LogError("Enemy needs an EnemyStateMachine!");
            return;
        }

        stateMachine.Initialize(this);
    }

  public void MoveTowards(Vector3 target, float speed)
{
    // Keep the target at the enemy's current height.
    target.y = transform.position.y;

    Vector3 direction = target - transform.position;

    if (direction.magnitude > 0.1f)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        transform.rotation = Quaternion.LookRotation(direction);
    }
}

 public float DistanceToPlayer()
{
    if (Player == null)
        return Mathf.Infinity;

    Vector3 enemyPosition = transform.position;
    Vector3 playerPosition = Player.position;

    // Ignore height difference.
    enemyPosition.y = 0f;
    playerPosition.y = 0f;

    return Vector3.Distance(
        enemyPosition,
        playerPosition
    );
}
    
   public void PlayAnimation(string animationName)
{
    Animator animator = GetComponent<Animator>();

    if (animator != null)
    {
        animator.Play(animationName);
    }
}
}
