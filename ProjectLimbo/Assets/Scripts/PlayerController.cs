using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigidBody;
    Collider2D sad;
    PlayerState currentState = PlayerState.Idle;
    public float JumpForce = 5;
    public float MovementSpeed = .05f;

    public bool facingRight = true;

	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        //pc controls
	    if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(MovementSpeed, 0, 0);

                if (!facingRight)
                {
                    Vector3 currentScale = transform.localScale;
                    currentScale.x = Mathf.Abs(currentScale.x);
                    transform.localScale = currentScale;
                    facingRight = true;
                }
                
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(-MovementSpeed, 0, 0);
                if (facingRight)
                {
                    facingRight = false;
                    Vector3 currentScale = transform.localScale;
                    currentScale.x = -Mathf.Abs(currentScale.x);
                    transform.localScale = currentScale;
                }
            }
            
            //if the player wants to jump and the character isn't jumping
            if (Input.GetKeyDown(KeyCode.Space) && currentState != PlayerState.Jumping)
            {
                //apply some force, the character is now jumping
                rigidBody.AddRelativeForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                currentState = PlayerState.Jumping;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        //player landed on a platform
        if(collider.CompareTag("Platform"))
        {
            currentState = PlayerState.Idle;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        //player fell off of a platform
        if (collider.CompareTag("Platform"))
        {
            currentState = PlayerState.Jumping;
        }
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //player is still on a platform
        if(collider.CompareTag("Platform"))
        {
            currentState = PlayerState.Idle;
        }
    }
}
