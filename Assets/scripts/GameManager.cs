using UnityEngine;

public class GameManager : MonoBehaviour
{
    // This stores the one and only GameManager in the game.
    public static GameManager Instance;

    // Player's current score/money.
    public int score = 0;
    public int health = 100;

    // Delivery and coin progress.
    public int deliveriesCompleted = 0;
    public int coinsCollected = 0;

    // Amount needed to complete the round.
    public int totalDeliveries = 10;
    public int totalCoins = 10;

    private bool roundCompleted = false;


    private void Awake()
    {
        // Check if a GameManager already exists.
        if (Instance != null && Instance != this)
        {
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
        GameEvents.CoinCollected += OnCoinCollected;
        GameEvents.DeliveryCompleted += OnDeliveryCompleted;
    }


    private void OnDisable()
    {
        GameEvents.CoinCollected -= OnCoinCollected;
        GameEvents.DeliveryCompleted -= OnDeliveryCompleted;
    }


    private void OnCoinCollected()
    {
        coinsCollected++;

        // Add 1 point for collecting a coin.
        score++;

        Debug.Log("Coins: " + coinsCollected + "/" + totalCoins);
        Debug.Log("Score: " + score);

        CheckRoundComplete();
    }


    private void OnDeliveryCompleted()
    {
        deliveriesCompleted++;

        // Add 1 point for completing a delivery.
        score++;

        Debug.Log("Deliveries: " + deliveriesCompleted + "/" + totalDeliveries);
        Debug.Log("Score: " + score);

        CheckRoundComplete();
    }


    private void CheckRoundComplete()
    {
        if (roundCompleted)
            return;

        if (coinsCollected >= totalCoins &&
            deliveriesCompleted >= totalDeliveries)
        {
            roundCompleted = true;

            Debug.Log("ROUND COMPLETED!");

            GameEvents.FireRoundCompleted();
        }
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