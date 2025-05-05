using UnityEngine;

public class CollisionJointCreator : MonoBehaviour
{
    public AudioClip stickSound; // Add this to assign the stick sound

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected! backshot = " + GameManager.backshot);
        if (other.CompareTag("Ground"))
        {
            // Create a FixedJoint2D and attach to the ground
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            Rigidbody2D groundRb = other.attachedRigidbody;

            if (groundRb != null)
            {
                joint.connectedBody = groundRb;
            }
            else
            {
                // If the ground doesn't have a Rigidbody2D, the joint will treat it as static
                joint.connectedBody = null;
            }

            // Play stick sound
            if (audioSource != null && stickSound != null)
            {
                audioSource.PlayOneShot(stickSound);
            }

            // Stop movement of this object and all its parents
            Transform current = transform;
            while (current != null)
            {
                Rigidbody2D rb = current.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                    rb.bodyType = RigidbodyType2D.Kinematic;
                }
                current = current.parent;
            }
        }
    }
}
