using UnityEngine;

public class SweeperObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touched the sweeper.
        if (other.CompareTag("Player"))
        {
            // Take 10 damage.
            GameManager.Instance.TakeDamage(10);

            Debug.Log("Sweeper hit the player!");
        }
    }
}