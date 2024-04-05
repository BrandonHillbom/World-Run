using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyBox : MonoBehaviour
{
    public Material[] skyboxes; // Array of skybox materials to switch between
    public int currentIndex = -1; // Current index of the active skybox

    void Start()
    {
        Update();
    }

    void Update()
    {
        int relicCount = GameManager.gameManager.getRelicCount() % 20; // Effective relic count within each cycle of 40

        // Determine which skybox to use based on relic count
        int newIndex = 0;
        if (relicCount >= 0 && relicCount <= 5)
        {
            newIndex = 0;
        }
        else if (relicCount >= 6 && relicCount <= 10)
        {
            newIndex = 1;
        }
        else if (relicCount >= 11 && relicCount <= 15)
        {
            newIndex = 2;
        }
         else if (relicCount >= 15 && relicCount <= 20)
        {
            newIndex = 3;
        }
        
        // Change the skybox if the index has changed
        if (newIndex != currentIndex && newIndex < skyboxes.Length)
        {
            RenderSettings.skybox = skyboxes[newIndex];
            currentIndex = newIndex;
        }
    }

}
