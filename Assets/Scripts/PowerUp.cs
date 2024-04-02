using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        //destroy powerup if the player runs into it 
        if (collider.gameObject.name == "Player") {
            Destroy(gameObject);

        }
    }
}
