using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int relicsCollected;
    public static GameManager gm;
    public TextMeshProUGUI relicsCollectedText;
    // Start is called before the first frame update
    public void IncrementRelicCount()
    {
        relicsCollected++;
        relicsCollectedText.text = "Relics: " + relicsCollected; //display text
        
    }

    private void Awake() {
        gm = this; //singleton 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
