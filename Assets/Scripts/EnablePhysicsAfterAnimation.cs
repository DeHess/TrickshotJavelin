using UnityEngine;

public class EnablePhysicsAfterAnimation : MonoBehaviour
{
    public float delay = 0.5f; // Time after which physics takes over

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Invoke enabling physics after animation duration
        Invoke("EnablePhysics", delay);
    }

    void EnablePhysics()
    {
        GetComponent<Animator>().enabled = false;
    }
}
