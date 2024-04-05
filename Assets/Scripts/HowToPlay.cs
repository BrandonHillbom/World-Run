using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HowToPlay : MonoBehaviour
{
    public TMP_Text instructionText; // Reference to the TextMeshPro text component for instructions
    public float displayDuration = 5f; // Duration for which instructions will be displayed

    private float startTime;

    void Start()
    {
        startTime = Time.time;
       // DisplayInstructions();
    }

    // void DisplayInstructions()
    // {
        
    // }

    void Update()
    {
        // Check if the time elapsed since the game started is greater than the display duration
        if (Time.time - startTime > displayDuration)
        {
            instructionText.text = ""; // Clear the instructions
        }
    }
}