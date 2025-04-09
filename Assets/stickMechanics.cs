using UnityEngine;

public class StopMomentumOnCollision : MonoBehaviour
{
    public Rigidbody parentRigidbody;
    public Rigidbody[] childRigidbodies;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StopMomentum();
        }
    }

    void StopMomentum()
    {
        parentRigidbody.linearVelocity = Vector3.zero;
        parentRigidbody.angularVelocity = Vector3.zero;

        foreach (Rigidbody rb in childRigidbodies)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
