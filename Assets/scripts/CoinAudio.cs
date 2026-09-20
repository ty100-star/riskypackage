using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    // The exact coin sound you want to play.
    [SerializeField] private AudioClip freesound_gamestudio_drop_coin_384921;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touched this coin.
        if (other.CompareTag("Player"))
        {
            // Check if the AudioManager exists.
            if (AudioManager.Instance == null)
            {
                Debug.LogError("AudioManager was NOT found!");
                return;
            }

            // Play the exact coin sound.
            AudioManager.Instance.PlaySFX(freesound_gamestudio_drop_coin_384921);

            // Tell us that the audio code ran.
            Debug.Log("Coin audio triggered!");
        }
    }
}