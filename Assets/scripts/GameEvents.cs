using System;

public static class GameEvents
{
    // Coin events
    public static event Action CoinCollected;

    // Delivery events
    public static event Action DeliveryCompleted;

    // Game events
    public static event Action PlayerDied;
    public static event Action RoundCompleted;


    // Tells everyone listening that a coin was collected.
    public static void FireCoinCollected()
    {
        CoinCollected?.Invoke();
    }

    // Tells everyone listening that a delivery was completed.
    public static void FireDeliveryCompleted()
    {
        DeliveryCompleted?.Invoke();
    }

    // Tells everyone listening that the player died.
    public static void FirePlayerDied()
    {
        PlayerDied?.Invoke();
    }

    // Tells everyone listening that the round has been completed.
    public static void FireRoundCompleted()
    {
        RoundCompleted?.Invoke();
    }
}