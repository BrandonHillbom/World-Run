using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObstacleMaterial : MonoBehaviour
{
    public Material[] obstacleMaterials; // Array of obstacle materials to switch between
    private Renderer obstacleRenderer; // Renderer of the obstacle object
    private ChangeSkyBox skyboxScript; // Reference to the ChangeSkyBox script

    void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
        skyboxScript = FindObjectOfType<ChangeSkyBox>(); // Find the ChangeSkyBox script in the scene
        UpdateMaterial();
    }

    void Update()
    {
        // Update the material when the skybox index changes
        if (skyboxScript != null && skyboxScript.currentIndex != -1)
        {
            UpdateMaterial();
        }
    }

    void UpdateMaterial()
    {
        int skyboxIndex = skyboxScript.currentIndex;
        if (skyboxIndex >= 0 && skyboxIndex < obstacleMaterials.Length)
        {
            obstacleRenderer.material = obstacleMaterials[skyboxIndex];
        }
    }
}
