using UnityEngine;

public class SpearLauncher : MonoBehaviour
{
    public Rigidbody2D spearRigidbody;
    public float launchForceMultiplier = 10f;

    private Vector2 dragStartPos;
    private bool isDragging = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        Debug.Log("down we go");
        dragStartPos = GetMouseWorldPosition();
        isDragging = true;
    }

    void OnMouseUp()
    {
        Debug.Log("Up we go");
        if (!isDragging) return;
        Debug.Log("still Going up strong");

        Vector2 dragEndPos = GetMouseWorldPosition();
        Vector2 launchDirection = dragStartPos - dragEndPos; // Opposite direction
        
        Debug.Log(launchDirection);

        spearRigidbody.bodyType = RigidbodyType2D.Dynamic; // In case it starts as kinematic
        spearRigidbody.linearVelocity = Vector2.zero;
        spearRigidbody.AddForce(launchDirection * launchForceMultiplier, ForceMode2D.Impulse);

        isDragging = false;
    }

    Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
