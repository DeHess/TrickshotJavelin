using System.Collections;
using UnityEngine;

public class PropelObject : MonoBehaviour
{
    public float forceAmount = 1000f; // Adjust this value to control the force
    private Rigidbody2D rb;
    private bool hasPropelled = false; // Ensure force is applied only once

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(RotateAndPropel());
    }

    IEnumerator RotateAndPropel()
    {
        // Rotate the object by 45 degrees
        transform.rotation = Quaternion.Euler(0, 0, 45);

        // Wait for 1 second
        yield return new WaitForSeconds(0.001f);

        // Apply force only once
        if (!hasPropelled)
        {
            rb.AddForce(transform.right * forceAmount, ForceMode2D.Impulse);
            hasPropelled = true;
            rb.gravityScale = 1; // Re-enable gravity after applying force
        }
    }
}