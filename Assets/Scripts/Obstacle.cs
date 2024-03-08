using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        
    }

    //called automatically when two objects collide
    private void OnCollisionEnter(Collision collision) {
        //the player must die
        if (collision.gameObject.name == "Player") {
            playerMovement.Die();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
