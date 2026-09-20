using UnityEngine;

public class SweeperRotation : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private void Update()
    {
        // Rotate horizontally around the world's Y axis.
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}