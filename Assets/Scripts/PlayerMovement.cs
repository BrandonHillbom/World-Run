using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    private bool turnLeft, turnRight, jump;
    public float speed = 10.0f;
    public float jumpForce = 50.0f; // The force applied when jumping
    private CharacterController myCharacterController;
    private Vector3 moveDirection = Vector3.zero;
   
    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
    }

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
    jump = Input.GetKey(KeyCode.Space); // Change to GetKeyDown

    if (turnLeft)
    {
        transform.Rotate(new Vector3(0f, -90f, 0f));
    }
    else if (turnRight)
    {
        transform.Rotate(new Vector3(0f, 90f, 0f));
    }

    moveDirection = transform.forward * speed * Time.deltaTime;
    float gravity = 9.8f;
        if (!myCharacterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            // Reset vertical velocity when grounded to avoid accumulating downward force
            moveDirection.y = 0f;
        }
        // Jumping  
        if (jump && myCharacterController.isGrounded)
        {
            Debug.Log("Character y position before jumpinng: " +  moveDirection.y);
            // Calculate jump velocity
            float jumpVelocity = Mathf.Sqrt(2 * jumpForce * gravity * Time.deltaTime);
            // Set vertical velocity to jump force
            moveDirection.y += jumpVelocity;
            Debug.Log("Character y position aftter jumpinng: " +  moveDirection.y);
        }
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
