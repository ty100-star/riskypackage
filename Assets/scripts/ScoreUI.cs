using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable()
    {
        GameEvents.CoinCollected += UpdateScoreUI;
        GameEvents.DeliveryCompleted += UpdateScoreUI;

        UpdateScoreUI();
    }

    private void OnDisable()
    {
        GameEvents.CoinCollected -= UpdateScoreUI;
        GameEvents.DeliveryCompleted -= UpdateScoreUI;
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
    }
}