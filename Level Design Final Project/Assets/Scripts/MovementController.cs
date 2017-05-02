using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float moveSpeed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 8f;

    private bool isJumping;
    private bool wasJumping;
    private bool wasGrounded;

    public int maxJumpCount = 1; //Maximum amount of times a player can consecutively jump (1 for single jump, 2 for double jump)
    private int jumpCount = 0; //Amount of times a player has consecutively jumped.

    private float oldJump;

    public bool movingEnabled = true; 

    public Vector3 moveDirection = Vector3.zero;

    public Vector3 moveOffset = Vector3.zero;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        CharacterController controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            //If there is no character controller on the character, alert the dev.
            Debug.LogWarning("No character controller attached!");
            return;
        }
        if (controller.isGrounded)
        {
            isJumping = false;
            jumpCount = 0;
            //If the player is on the ground, don't push them downward.
            //moveDirection.y = 0;
        } else {
            //If the player is off the ground, push them downward.
            moveDirection.y -= gravity * Time.deltaTime;
        }
        //Handle jumping.
        float jump = Input.GetAxis("Jump");
        if (!movingEnabled)
        {
            //If the player isn't allowed to move, cancel the jump.
            jump = 0;
        }
        if (jump==1f && oldJump != 1f && jumpCount<maxJumpCount)
        {
            //If the player has pressed the jump button and can jump, jump.
            jumpCount++;
            moveDirection.y = jumpSpeed;
            isJumping = true;
        }
        
        //This activates right as the player lands at all.
        if (controller.isGrounded && !wasGrounded)
        {
            Debug.Log("Landed");
            isJumping = false;
            jumpCount = 0;
        }

        //This activates right as the player lands after jumping.
        if (wasJumping && !isJumping)
        {
            
        }


        //Get left and right movement.
        float horiz = Input.GetAxis("Horizontal");
        if (!movingEnabled)
        {
            //If the player isn't allowed to move, cancel the movement.
            horiz = 0f;
        }
        moveDirection.x = horiz * moveSpeed;
        controller.Move((moveDirection * Time.deltaTime) + moveOffset);
        //moveOffset = Vector3.zero;
        oldJump = jump;
        wasJumping = isJumping;
        wasGrounded = controller.isGrounded;
	}
}
