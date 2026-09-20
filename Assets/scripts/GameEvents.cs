using System;

public static class GameEvents
{
    // This event happens when the player collects a coin.
    public static event Action CoinCollected;

    // This event will happen when the player dies.
    public static event Action PlayerDied;

    // Tells everyone listening that a coin was collected.
    public static void FireCoinCollected()
    {
        CoinCollected?.Invoke();
    }

    // Tells everyone listening that the player died.
    public static void FirePlayerDied()
    {
        PlayerDied?.Invoke();
    }
}