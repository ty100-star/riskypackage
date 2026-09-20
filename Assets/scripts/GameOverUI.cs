using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void OnEnable()
    {
        // Listen for the PlayerDied event.
        GameEvents.PlayerDied += ShowGameOver;
    }

    private void OnDisable()
    {
        // Stop listening when disabled.
        GameEvents.PlayerDied -= ShowGameOver;
    }

    private void ShowGameOver()
    {
        // Show the Game Over panel.
        gameOverPanel.SetActive(true);
    }
}