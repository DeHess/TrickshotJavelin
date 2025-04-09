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
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector2 dragEndPos = GetMouseWorldPosition();
            Vector2 launchDirection = dragStartPos - dragEndPos;

            spearRigidbody.bodyType = RigidbodyType2D.Dynamic;
            spearRigidbody.linearVelocity = Vector2.zero;
            spearRigidbody.AddForce(launchDirection * launchForceMultiplier, ForceMode2D.Impulse);

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
