// BackshotTrigger.cs
using System.Diagnostics;
using UnityEngine;

public class BackshotTrigger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("Collision detected on shadt");
        GameManager.backshot = true;
        
    }
}
