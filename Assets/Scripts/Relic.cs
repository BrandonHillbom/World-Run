using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider) {
        //destroy coin if the player runs into it 
        if (collider.gameObject.name == "Player") {
            Destroy(gameObject);
            GameManager.gameManager.IncrementRelicCount(); //increment relic count
        }
    }
}
