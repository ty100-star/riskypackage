using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public SphereCollider collider = new SphereCollider();

    void Start()
    {
        collider = GetComponent<SphereCollider>();
    }

  public void OnTriggerEnter(Collider other)
{
    // Adding score
    Debug.Log("Coin touched");

    // Tell the game that a coin was collected.
    GameEvents.FireCoinCollected();

    Destroy(gameObject);
}
}