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

   /* Apply gravity
    float gravity = 9.8f; // Move gravity calculation out of the if statement
   moveDirection.y -= gravity * Time.deltaTime;

    Jumping  
    if (myCharacterController.isGrounded)
   {
        if(jump){
        Debug.Log("Character y position before jumpinng: " +  moveDirection.y);
        Vector3 jumpDirection = -transform.forward;
        jumpDirection.y = 0f;
        moveDirection = jumpDirection * speed * Time.deltaTime;
        moveDirection.y = jumpForce;
        myCharacterController.Move(moveDirection);
        Debug.Log("Character y position aftter jumpinng: " +  moveDirection.y);
        }
    }
     jumping algorithm problem  when space bar  is pressed  player position its over ridden  then the playing start falling
    */

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
   // Calculate jump force to be applied
    float jumpVelocity = Mathf.Sqrt(2 * jumpForce * gravity);
    // Set vertical velocity to jump force
    moveDirection.y = jumpVelocity;
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
