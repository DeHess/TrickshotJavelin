using UnityEngine;

public class BreakOnHit : MonoBehaviour
{
    public GameObject brokenVersion; // Drag the BrokenSquare prefab here
    public GameObject floatingTextPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpearTip"))
        {
            Instantiate(brokenVersion, transform.position, Quaternion.identity);
            Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            ScoreManager.instance.AddPoints(100);
            Destroy(gameObject);
        }
    }
}