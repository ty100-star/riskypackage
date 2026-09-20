using UnityEngine;

public class GameManager : MonoBehaviour
{
    // This stores the one and only GameManager in the game.
    public static GameManager Instance;

    // Player's current score/money.
    public int score = 0;
    public int health = 100;

    // Number of deliveries the player has completed.
    public int deliveriesCompleted = 0;


    private void Awake()
    {
        // Check if a GameManager already exists.
        if (Instance != null && Instance != this)
        {
            // If another one exists, destroy this duplicate.
            Destroy(gameObject);
            return;
        }

        // This GameManager becomes the main instance.
        Instance = this;

        // Keep this GameManager when changing/reloading scenes.
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
{
    // Listen for the CoinCollected event.
    GameEvents.CoinCollected += AddScore;
}

private void OnDisable()
{
    // Stop listening when this object is disabled.
    GameEvents.CoinCollected -= AddScore;
}

private void AddScore()
{
    // Add 1 point whenever a coin is collected.
    score++;

    Debug.Log("Score: " + score);
}
public void TakeDamage(int damage)
{
    // Remove health from the player.
    health -= damage;

    // Don't let health go below 0.
    health = Mathf.Max(health, 0);

    Debug.Log("Health: " + health);

    // Player dies when health reaches 0.
    if (health <= 0)
    {
        GameEvents.FirePlayerDied();
    }
}
}