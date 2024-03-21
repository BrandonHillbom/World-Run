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

        moveDirection = transform.forward * speed * Time.deltaTime;
        myCharacterController.Move(moveDirection);

        if (!myCharacterController.isGrounded){
            float gravity = 9.8f;
            Vector3 gravityMovement = Vector3.down * gravity * Time.deltaTime;
            myCharacterController.Move(gravityMovement);
        }
    }

    public void Die() {
        alive = false;
        //restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Obstacle"){
			Die();
		}
	}
}