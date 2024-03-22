using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RuntimeDisplay : MonoBehaviour
{
public TMP_Text runtimeText; // Reference to the TextMeshPro text component for displaying runtime
    private float startTime; // Start time of the game

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        UpdateRuntimeText();
    }

    void UpdateRuntimeText()
    {
        float runTime = Time.time - startTime;
        string minutes = Mathf.Floor(runTime / 60).ToString("00");
        string seconds = (runTime % 60).ToString("00");
        runtimeText.text = "Runtime: " + minutes + ":" + seconds;
    }
}
