using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;

    private void Start()
    {
        // Show the player's starting health.
        UpdateHealthUI();
    }

    private void Update()
    {
        // Keep the displayed health up to date.
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthText.text = "Health: " + GameManager.Instance.health;
    }
}