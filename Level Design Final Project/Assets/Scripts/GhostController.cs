using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {


    public GameObject player;

    public bool isGhost = false;

    public float defaultTime = 10f;
    public float timeLeft = 0;

    public float oldControlValue = 1f;

    public GameManager manager;
    public FlashController flash;
	// Use this for initialization
	void Start () {
        oldControlValue = 1f;
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (manager == null)
        {
            Debug.LogWarning("No GameManager found!");
        }
        flash = GameObject.Find("Flash Screen").GetComponent<FlashController>();
        if (flash == null)
        {
            Debug.LogWarning("No Flash Screen Found!");
        }
		if (transform.name == "Player")
        {
            //If this is the player, set isGhost to false.
            player = this.gameObject;
            isGhost = false;
        } else
        {
            //If this is not the player, assume it's the ghost.
            isGhost = true;
            //Find the player and get it's default time value for this ghost's life.
            player = GameObject.Find("Player");
            timeLeft = player.GetComponent<GhostController>().defaultTime;
            //Make the player unable to move.
            player.GetComponent<MovementController>().movingEnabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        bool risingEdge = false;
        if (Input.GetAxis("Ghost")==1f && oldControlValue == 0)
        {
            risingEdge = true;
        }
        if (isGhost)
        {
            //If this is a ghost, decrement it's timer.
            timeLeft -= Time.deltaTime;
            //Debug.Log(timeLeft);
            if (timeLeft <= 0f)
            {
                manager.updateObjects(false);
                //If the timer is out, kill the ghost.
                killGhost();
            }
            if (risingEdge)
            {
                manager.updateObjects(false);
                killGhost();
            }
        } else
        {
            //If this is not a ghost and the player presses the ghost button, create a ghost prefab.
            if (risingEdge && GameObject.Find("Ghost") == null)
            {
                flash.flash();
                manager.updateObjects(true);
                GameObject ghost = (GameObject)Instantiate(Resources.Load("Ghost"));
                ghost.transform.name = "Ghost";
                ghost.transform.position = transform.position;
                
            }
        }
        oldControlValue = Input.GetAxis("Ghost");
	}

    void killGhost()
    {
        flash.flash();
        player.GetComponent<MovementController>().movingEnabled = true;
        Destroy(this.gameObject);
    }
}
