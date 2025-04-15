using UnityEngine;

public class BreakOnHit : MonoBehaviour
{
    public GameObject brokenVersion; // Drag the BrokenSquare prefab here

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpearTip"))
        {
            Instantiate(brokenVersion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}