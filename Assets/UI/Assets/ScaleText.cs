using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScaleText : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public TextMeshProUGUI scaleText; // Reference to the TextMeshPro UI Text component

    void Update()
    {
        if (playerTransform != null && scaleText != null)
        {
            // Get the x component of the player's scale
            float scaleX = playerTransform.localScale.x;

            // Display the scale in the TextMeshPro UI Text
            scaleText.text = "Player Scale: " + scaleX.ToString("F2");
        }
    }
}
