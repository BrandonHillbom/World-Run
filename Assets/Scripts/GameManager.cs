using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int relicCount;
    public TextMeshProUGUI relicCountText;
    public TextMeshProUGUI powerUpText; // Add reference to the power-up text
    public static GameManager gameManager;

    private float remainingPowerUpTime = 11f; // Variable to store remaining power-up time

    private void Awake()
    {
        gameManager = this; //singleton method to initialize
    }

    public int getRelicCount()
    {
        return relicCount;
    }

    public void IncrementRelicCount()
    {
        relicCount++;
        relicCountText.text = "RELICS COLLECTED: " + relicCount;
    }

      // Method to set remaining power-up time
    public void SetRemainingPowerUpTime(float remainingTime)
    {
        remainingPowerUpTime = remainingTime;
    }

    
    // Method to update power-up text
    public void UpdatePowerUpText(bool hasPowerUp)
    {
        if (hasPowerUp)
        {
        string minutes = Mathf.Floor(remainingPowerUpTime / 60).ToString("00");
        string seconds = (remainingPowerUpTime % 60).ToString("00");
        powerUpText.text = "Invincibility: " + minutes + ":" + seconds;
            //powerUpText.text = "ACTIVE";
        }
        else
        {
            powerUpText.text = "";
        }
    }

  

    
}
