using UnityEngine;
using UnityEngine.UI;

public class HandCursorSwap : MonoBehaviour
{
    public Sprite handOpen;
    public Sprite handClosed;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        // Cursor.visible = false; // Hide system cursor
        image.sprite = handOpen;
    }

    void Update()
    {
        // Change sprite based on mouse input
        if (Input.GetMouseButton(0))
        {
            image.sprite = handClosed;
        }
        else
        {
            image.sprite = handOpen;
        }

        // Follow cursor
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.GetComponent<RectTransform>(),
            Input.mousePosition,
            null,
            out pos
        );
        GetComponent<RectTransform>().anchoredPosition = pos;
    }
}
