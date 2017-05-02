using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    Animator animator;

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

        if (mc.moveDirection.x != 0)
        {
            is_running = true;
        } else
        {
            is_running = false;
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
