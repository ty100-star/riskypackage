using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance { get; private set; }

    [Header("Delivery")]
    public GameObject boxPrefab;
    public Transform boxHoldPoint;
    public DeliveryZone[] deliveryZones;

    private int currentDelivery = 0;
    private GameObject currentBox;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        SpawnNextBox();
    }

    private void SpawnNextBox()
    {
        currentBox = Instantiate(boxPrefab);

        currentBox.transform.SetParent(boxHoldPoint);

        currentBox.transform.localPosition = Vector3.zero;
        currentBox.transform.localRotation = Quaternion.identity;
    }

    public bool IsCurrentDelivery(DeliveryZone zone)
    {
        return deliveryZones[currentDelivery] == zone;
    }

    public void CompleteDelivery(DeliveryZone zone)
    {
        if (!IsCurrentDelivery(zone))
            return;

        Debug.Log("CompleteDelivery was called!");

        // Give the player 1 point using the existing score system.
        GameEvents.FireDeliveryCompleted();

        // Destroy the box that was just delivered.
        if (currentBox != null)
        {
            Debug.Log("DESTROYING: " + currentBox.name);
            Destroy(currentBox);
            currentBox = null;
        }
        else
        {
            Debug.Log("CURRENT BOX IS NULL!");
        }

        // Move to the next delivery.
        currentDelivery++;

        Debug.Log("Moving to delivery number: " + currentDelivery);

        // Spawn the next box if there are more deliveries.
        if (currentDelivery < deliveryZones.Length)
        {
            Debug.Log("Spawning next box!");
            SpawnNextBox();
        }
        else
        {
            Debug.Log("All deliveries complete!");
        }
    }
}