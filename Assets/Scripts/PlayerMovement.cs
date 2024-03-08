using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    private bool turnLeft, turnRight;
    public float speed = 10.0f;
    private CharacterController myCharacterController;
    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive) return;

        if (transform.position.y < -5) {
            Die(); //if player falls off left side
        } 
        
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);

        if (turnLeft) {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        } else if (turnRight) {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }

        myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);
        
    }

    public void Die() {
        alive = false;
        //restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
