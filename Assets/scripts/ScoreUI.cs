using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable()
    {
        // Listen for the CoinCollected event.
        GameEvents.CoinCollected += UpdateScoreUI;

        // Show the starting score immediately.
        UpdateScoreUI();
    }

    private void OnDisable()
    {
        // Stop listening when this UI is disabled.
        GameEvents.CoinCollected -= UpdateScoreUI;
    }

    private void UpdateScoreUI()
    {
        // Display the score from the GameManager.
        scoreText.text = "Score: " + GameManager.Instance.score;
    }
}