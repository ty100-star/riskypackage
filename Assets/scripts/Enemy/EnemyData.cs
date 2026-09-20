using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float chaseSpeed = 4f;

    [Header("Combat")]
    public float attackRange = 2f;
    public float detectionRange = 10f;
    public float health = 100f;
}
