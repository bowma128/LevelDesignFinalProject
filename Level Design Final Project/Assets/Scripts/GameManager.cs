using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int realWorldLayer;
    public int ghostWorldLayer;

    public Camera mainCamera;

    public FlashController flash;

    public bool is_ghostMode = false;

    private bool waitingToSwitch = false;

    public Vector3 current_checkpoint;

    public int lives;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (mainCamera == null)
        {
            Debug.LogWarning("No camera found in scene!");
        }
        flash = GameObject.Find("Flash Screen").GetComponent<FlashController>();
        if (flash == null)
        {
            Debug.LogWarning("No flash found!");
        }

        //set the current checkpoint to wherever the player is at the start.
        current_checkpoint = GameObject.Find("Player").transform.position;
        //Set up all colliders and renderers.
        updateObjects(false);
        Physics.IgnoreLayerCollision(11, 9, true);
        Physics.IgnoreLayerCollision(8, 12, true);
        Physics.IgnoreLayerCollision(11, 12, true);
    }
	// Update is called once per frame
	void Update () {
        if (flash.screenCovered && waitingToSwitch)
        {
            waitingToSwitch = false;
            internal_updateObjects(is_ghostMode);
        }
	}

    public void updateObjects(bool ghostMode)
    {
        is_ghostMode = ghostMode;
        waitingToSwitch = true;
    }

    public void loseLife()
    {
        lives--;
    }

    public void internal_updateObjects(bool ghostMode)
    {
        if (ghostMode)
        {
            //Set the camera's culling mask.
            mainCamera.cullingMask = -257; //This will only render objects in the ghost world.
        } else
        {
            mainCamera.cullingMask = -513; //This will only render objects in the real world.
        }
        
        /*foreach (GameObject g in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (ghostMode)
            {
                //If in ghost mode, enable all colliders in the ghost world. 
                if (g.layer == ghostWorldLayer)
                {
                    //The object is a ghost mode object. Show it and turn on it's colliders.
                    BoxCollider coll = g.GetComponent<BoxCollider>();
                    if (coll != null)
                    {
                        //coll.enabled = true;
                    }
                } else if (g.layer == realWorldLayer)
                {
                    BoxCollider coll = g.GetComponent<BoxCollider>();
                    if (coll != null)
                    {
                        //coll.enabled = false;
                    }
                }
            } else
            {
                if (g.layer == ghostWorldLayer)
                {
                    //The object is a ghost mode object. Show it and turn on it's colliders.
                    BoxCollider coll = g.GetComponent<BoxCollider>();
                    if (coll != null)
                    {
                        //coll.enabled = false;
                    }
                }
                else if (g.layer == realWorldLayer)
                {
                    BoxCollider coll = g.GetComponent<BoxCollider>();
                    if (coll != null)
                    {
                        //coll.enabled = true;
                    }
                }
            }
        }*/
    }
}
