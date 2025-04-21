using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float lifetime = 1f;
    public Vector3 floatDirection = Vector3.up;

    private TextMeshProUGUI tmp;
    private Color originalColor;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        originalColor = tmp.color;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += floatDirection * floatSpeed * Time.deltaTime;

        // Fade out
        float alpha = Mathf.Lerp(1f, 0f, Time.deltaTime / lifetime);
        tmp.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
    }
}
