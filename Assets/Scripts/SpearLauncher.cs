using UnityEngine;

public class SpearLauncher : MonoBehaviour
{
    public Rigidbody2D spearRigidbody;
    public float launchForceMultiplier = 15f;
    public LineRenderer directionLine;
    public AudioClip gruntSound; // Add this to assign the grunt sound

    private AudioSource audioSource;
    private Vector2 dragStartPos;
    private bool isDragging = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        audioSource = gameObject.AddComponent<AudioSource>();

        if (directionLine != null)
        {
            directionLine.positionCount = 2;
            directionLine.enabled = false;
        }
        directionLine.startWidth = 0.02f;
        directionLine.endWidth = 0.02f;
        directionLine.startColor = Color.white;
        directionLine.endColor = Color.white;
        directionLine.material = new Material(Shader.Find("Unlit/Color"));
        directionLine.material.color = Color.white;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = GetMouseWorldPosition();
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 currentDragPos = GetMouseWorldPosition();
            Vector2 dragDirection = dragStartPos - currentDragPos;

            float angle = Mathf.Atan2(dragDirection.y, dragDirection.x) * Mathf.Rad2Deg;
            spearRigidbody.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            if (directionLine != null)
            {
                directionLine.enabled = true;
                directionLine.SetPosition(0, spearRigidbody.transform.position);
                directionLine.SetPosition(1, spearRigidbody.transform.position + (Vector3)(dragDirection.normalized * 5f));
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector2 dragEndPos = GetMouseWorldPosition();
            Vector2 launchDirection = dragStartPos - dragEndPos;

            spearRigidbody.bodyType = RigidbodyType2D.Dynamic;
            spearRigidbody.linearVelocity = Vector2.zero;
            spearRigidbody.AddForce(launchDirection * launchForceMultiplier, ForceMode2D.Impulse);

            if (audioSource != null && gruntSound != null)
            {
                audioSource.PlayOneShot(gruntSound); // Play grunt sound here
            }

            if (directionLine != null)
                directionLine.enabled = false;

            isDragging = false;
        }
    }

    Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
