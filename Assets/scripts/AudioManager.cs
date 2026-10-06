using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Stores the one and only AudioManager.
    public static AudioManager Instance;

    // The AudioSource that plays our sounds.
    public AudioSource audioSource;

    // The sound we want to play when a coin is collected.
    public AudioClip coinSound;

    // The sound we want to play when a delivery is completed.
    public AudioClip deliveryCompleteSound;

    private void OnEnable()
    {
        GameEvents.CoinCollected += PlayCoinSound;
        GameEvents.DeliveryCompleted += PlayDeliveryCompleteSound;
    }

    private void OnDisable()
    {
        GameEvents.CoinCollected -= PlayCoinSound;
        GameEvents.DeliveryCompleted -= PlayDeliveryCompleteSound;
    }

    private void Awake()
    {
        // Check if another AudioManager already exists.
        if (Instance != null && Instance != this)
        {
            // Destroy the duplicate.
            Destroy(gameObject);
            return;
        }

        // Make this the main AudioManager.
        Instance = this;

        // Keep the AudioManager when changing scenes.
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
    }

    // Plays any sound effect we give it.
    public void PlaySFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // Plays the coin sound.
    public void PlayCoinSound()
    {
        PlaySFX(coinSound);
    }

    // Plays the delivery complete sound.
    public void PlayDeliveryCompleteSound()
    {
        PlaySFX(deliveryCompleteSound);
    }
}