using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Animator animator;

    public MovementController mc;

    public bool is_running;
    private bool was_running;
	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        mc = transform.parent.GetComponent<MovementController>();
        if (mc==null)
        {
            Debug.LogWarning("No movement controller attached to animation controller!");
        }
	}
	
	// Update is called once per frame
	void Update () {

        transform.localPosition =  new Vector3(0, transform.localPosition.y, 0);
        if (mc.isJumping)
        {
            animator.SetBool("isJumping", true);
        } else
        {
            animator.SetBool("isJumping", false);
        }
        if (mc.moveDirection.x != 0)
        {
            is_running = true;
            animator.SetBool("isRunning", true);
            if (mc.moveDirection.x>0)
            {
                //The player is moving right
                transform.eulerAngles = new Vector3(0, 101, 0);
            } else
            {
                transform.eulerAngles = new Vector3(0, 281, 0);
            }
        } else
        {
            is_running = false;
            animator.SetBool("isRunning", false);
        }
        if (is_running && !was_running)
        {
            //If the player has just started running
        }
        if (!is_running && was_running)
        {
            //If the player just stopped running
        }

        was_running = is_running;
	}
}
