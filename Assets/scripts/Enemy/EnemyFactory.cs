using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [Header("Enemy Prefab")]
    public GameObject enemyPrefab;

    [Header("Enemy Types")]
    public EnemyData[] enemyData;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    [Header("Player")]
    public Transform player;

    [Header("Patrol Points")]
    public Transform[] patrolPoints;

    private void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("EnemyFactory: Enemy Prefab is missing!");
            return;
        }

        if (enemyData == null || enemyData.Length == 0)
        {
            Debug.LogError("EnemyFactory: Enemy Data is missing!");
            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("EnemyFactory: Spawn Points are missing!");
            return;
        }

        for (int i = 0; i < enemyData.Length; i++)
        {
            if (i >= spawnPoints.Length)
                break;

            GameObject newEnemy = Instantiate(
                enemyPrefab,
                spawnPoints[i].position,
                Quaternion.identity
            );

            newEnemy.name = enemyData[i].enemyName;

            EnemyController controller =
                newEnemy.GetComponent<EnemyController>();

            if (controller != null)
            {
                controller.Initialize(
                    enemyData[i],
                    player,
                    patrolPoints
                );
            }
        }
    }
}