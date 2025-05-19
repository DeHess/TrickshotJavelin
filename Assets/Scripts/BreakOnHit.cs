// 19/05/2025 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;

public class BreakOnHit : MonoBehaviour
{
    public GameObject brokenVersion; // Drag the BrokenSquare prefab here
    public GameObject floatingTextPrefab;
    public AudioClip breakSound; // Assign the break sound in the Inspector

    private AudioSource audioSource;
    private MeshRenderer meshRenderer;
    private Collider2D collider;

    void Start()
    {
        // Get required components
        audioSource = gameObject.AddComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider2D>();

        if (audioSource == null || meshRenderer == null || collider == null)
        {
            Debug.LogError("Missing required components on Seagull object.");
        }

        audioSource.playOnAwake = false; // Ensure the sound doesn't play at startup
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Disable the visual and physical components
        if (meshRenderer != null) meshRenderer.enabled = false;
        if (collider != null) collider.enabled = false;

        // Play the break sound
        if (audioSource != null && breakSound != null)
        {
            audioSource.clip = breakSound;
            audioSource.Play();
        }
        Instantiate(brokenVersion, transform.position, Quaternion.identity);
        Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        ScoreManager.instance.AddPoints(100);

        // Destroy the GameObject after the sound finishes playing
        Destroy(gameObject, breakSound.length);
    }
}