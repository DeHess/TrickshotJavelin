using UnityEngine;

public class BreakOnHit : MonoBehaviour
{
    public GameObject brokenVersion; // Drag the BrokenSquare prefab here

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.CompareTag("Spear"))
        {
            Instantiate(brokenVersion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}