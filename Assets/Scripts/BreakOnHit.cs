using UnityEngine;

public class BreakOnHit : MonoBehaviour
{
    public GameObject brokenVersion; // Drag the BrokenSquare prefab here
    public GameObject floatingTextPrefab;
    public AudioClip breakSound; // Add this to assign the sound file

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpearTip"))
        {
            audioSource.PlayOneShot(breakSound); // Play the break sound

            Instantiate(brokenVersion, transform.position, Quaternion.identity);
            Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            ScoreManager.instance.AddPoints(100);
            Destroy(gameObject, breakSound.length); // Delay destroy so sound plays
        }
    }
}
