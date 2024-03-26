using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int relicCount;
    public TextMeshProUGUI relicCountText;
    public static GameManager gameManager;

    private void Awake() {
        gameManager = this; //singleton method to initialize
    }

    public int getRelicCount() {
        return relicCount;
    }

    public void IncrementRelicCount() {
        relicCount++;
        relicCountText.text = "RELICS COLLECTED: " + relicCount;
    }

}
