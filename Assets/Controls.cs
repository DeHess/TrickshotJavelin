using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust speed in Inspector

    void Update()
    {
        if (Input.GetMouseButton(0)) // 0 is left mouse button
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
