// 19/05/2025 AI-Tag
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NpcSentenceController : MonoBehaviour
{
    public TextMeshProUGUI npcSentenceText; // Reference to the Text component for the NPC's speech

    public void UpdateSentence(int points)
    {
        // Change the NPC's sentence based on the points
        if (points < 100)
        {
            npcSentenceText.text = "You are good for nothing";
        }
        else if (points < 200)
        {
            npcSentenceText.text = "Still not good enough!";
        }
        else if (points < 300)
        {
            npcSentenceText.text = "You might not be all that worthless";
        }
        else
        {
            npcSentenceText.text = "What is this feeling? Am I proud of you?";
        }
    }
}
