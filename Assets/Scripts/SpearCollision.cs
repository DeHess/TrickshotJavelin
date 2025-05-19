// 19/05/2025 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System;
using UnityEditor;
using UnityEngine;

public class SpearCollision : MonoBehaviour
{
    public NpcSentenceController npcController; // Reference to NPC's sentence controller

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the spear hits the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Notify the NPC to update its sentence based on player points
            if (npcController != null)
            {
                Debug.Log("npc say something");
                npcController.UpdateSentence(ScoreManager.instance.GetPoints());
            }
        }
    }
}
