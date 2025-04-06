using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object to follow
    public Vector3 offset = new Vector3(0, 5, -10); // Default offset

    void LateUpdate()
    {
        if (target == null)
            return;

        // Set camera position directly
        transform.position = target.position + offset;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
