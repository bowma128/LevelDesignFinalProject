using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {


    public GameObject player;

    public bool isGhost = false;

    public float defaultTime = 10f;
    public float timeLeft = 0;

    public GameManager manager;

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (manager == null)
        {
            Debug.LogWarning("No GameManager found!");
        }
		if (transform.name == "Player")
        {
            //If this is the player, set isGhost to false.
            player = this.gameObject;
            isGhost = false;
        } else
        {
            Debug.Log("Ghost created!");
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
        } else
        {
            //If this is not a ghost and the player presses the ghost button, create a ghost prefab.
            if (Input.GetAxis("Ghost") == 1f && GameObject.Find("Ghost") == null)
            {
                manager.updateObjects(true);
                GameObject ghost = (GameObject)Instantiate(Resources.Load("Ghost"));
                ghost.transform.name = "Ghost";
                ghost.transform.position = transform.position + new Vector3(0, 2, 0);
            }
        }
	}

    void killGhost()
    {
        player.GetComponent<MovementController>().movingEnabled = true;
        Destroy(this.gameObject);
    }
}
