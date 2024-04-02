using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    bool hasPowerUp = false;
    
    private bool turnLeft, turnRight, jump;
    public float speed = 10.0f;
    public float jumpForce = 80.0f; // The force applied when jumping
    private float PowerUpStartTime;
    float remainingPowerUpTime; 
    private CharacterController myCharacterController;
    private Vector3 moveDirection = Vector3.zero;
    private GameManager gameManager;
   
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gameManager;
        myCharacterController = GetComponent<CharacterController>();
        // Reset power-up state and timer on respawn
            hasPowerUp = false;
            PowerUpStartTime = Time.time;
    
    }

    // Update is called once per frame
void Update()
{
    if (!alive) return;
    speed+= 0.000001f;
    if (transform.position.y < -5)
    {
        hasPowerUp= false;
        Die(); //if player falls off left side
    }
    PowerUpCountDown();
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
           // Debug.Log("Character y position before jumpinng: " +  moveDirection.y);
            // Calculate jump velocity
            float jumpVelocity = Mathf.Sqrt(2 * jumpForce * gravity * Time.deltaTime);
            // Set vertical velocity to jump force
            moveDirection.y += jumpVelocity;
          //  Debug.Log("Character y position aftter jumpinng: " +  moveDirection.y);
        }
    myCharacterController.Move(moveDirection);
    gameManager.UpdatePowerUpText(hasPowerUp);
    gameManager.SetRemainingPowerUpTime(remainingPowerUpTime);
}


    public void Die()
    {
        
        alive = false;
        //restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle" && hasPowerUp == false)
        {
            Die();
        }
        else if (other.gameObject.tag == "PowerUp") // Check if collided with power-up
        {
            hasPowerUp = true; // Set the flag to true
            Destroy(other.gameObject); // Destroy the power-up object
        }
    }

    public void PowerUpCountDown()
    {
        float PowerUpDuratation = 15f; 
        float elapsedTime = Time.time - PowerUpStartTime;
        remainingPowerUpTime = PowerUpDuratation - elapsedTime;
        
        if (remainingPowerUpTime <= 0)
        {   
            hasPowerUp = false;
            remainingPowerUpTime = 0;
            
        }
    }
}
