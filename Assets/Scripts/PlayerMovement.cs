using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    private bool turnLeft, turnRight, jump;
    public float speed = 10.0f;
    public float jumpForce = 8.0f; // The force applied when jumping
    private CharacterController myCharacterController;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z); 
    }

    // Update is called once per frame
  // Update is called once per frame
void Update()
{
    if (!alive) return;

    if (transform.position.y < -5)
    {
        Die(); //if player falls off left side
    }

    turnLeft = Input.GetKeyDown(KeyCode.A);
    turnRight = Input.GetKeyDown(KeyCode.D);
    jump = Input.GetKeyDown(KeyCode.Space); // Change to GetKeyDown

    if (turnLeft)
    {
        transform.Rotate(new Vector3(0f, -90f, 0f));
    }
    else if (turnRight)
    {
        transform.Rotate(new Vector3(0f, 90f, 0f));
    }

    moveDirection = transform.forward * speed * Time.deltaTime;

    // Apply gravity
    float gravity = 9.8f; // Move gravity calculation out of the if statement
    moveDirection.y -= gravity * Time.deltaTime;

    // Jumping  
    if (myCharacterController.isGrounded && jump)
    {
        moveDirection.y = jumpForce; 
        Debug.Log("Grounded: " + myCharacterController.isGrounded);
        Debug.Log("Jump Key Pressed: " + jump);
    }

    // Apply movement 
    myCharacterController.Move(moveDirection);
}


    public void Die()
    {
        alive = false;
        //restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }
}
