using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        // if (collider.gameObject.GetComponent<Obstacle>() != null) { //if the relic is in an obstacle then return and delete the relic
        //     Destroy(gameObject);
        //     return;
        // }
        if (collider.gameObject.name == "Player") { 
             Destroy(gameObject); //Player has collected relic, now get rid of it
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
