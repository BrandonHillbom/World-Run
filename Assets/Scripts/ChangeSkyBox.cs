using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyBox : MonoBehaviour
{
	public Material[] skyboxes; // Array of skybox materials to switch between
    public float changeInterval = 30.0f; // Time interval to change skybox
    private float elapsedTime = 0.0f;
    private int currentIndex = 0;

    void Start()
    {
        RenderSettings.skybox = skyboxes[currentIndex]; // Set initial skybox
    }

    void Update()
    {
        // Update elapsed time
        elapsedTime += Time.deltaTime;

        // Check if it's time to change the skybox
        if (elapsedTime >= changeInterval)
        {
            // Reset timer
            elapsedTime = 0.0f;

            // Increment index or loop back to the beginning if reached the end
            currentIndex = (currentIndex + 1) % skyboxes.Length;

            // Change skybox
            RenderSettings.skybox = skyboxes[currentIndex];
        }
    }
}
