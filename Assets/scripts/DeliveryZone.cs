using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    private bool delivered = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SOMETHING ENTERED THE DELIVERY ZONE: " + other.name);

        if (delivered)
            return;

        if (!other.CompareTag("Player"))
        {
            Debug.Log("It was not the Player.");
            return;
        }

        Debug.Log("PLAYER ENTERED DELIVERY ZONE!");

        if (DeliveryManager.Instance.IsCurrentDelivery(this))
        {
            Debug.Log("CORRECT DELIVERY ZONE!");

            delivered = true;
            DeliveryManager.Instance.CompleteDelivery(this);
        }
        else
        {
            Debug.Log("WRONG DELIVERY ZONE!");
        }
    }
}