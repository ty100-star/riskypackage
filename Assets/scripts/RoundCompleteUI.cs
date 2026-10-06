using UnityEngine;

public class RoundCompleteUI : MonoBehaviour
{
    [SerializeField] private GameObject roundCompletePanel;

    private void Start()
    {
        roundCompletePanel.SetActive(false);
    }

    private void OnEnable()
    {
        GameEvents.RoundCompleted += ShowRoundComplete;
    }

    private void OnDisable()
    {
        GameEvents.RoundCompleted -= ShowRoundComplete;
    }

    private void ShowRoundComplete()
    {
        roundCompletePanel.SetActive(true);
    }
}