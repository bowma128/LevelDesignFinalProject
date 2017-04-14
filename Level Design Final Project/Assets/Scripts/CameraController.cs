using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;
    public Vector3 offset = new Vector3(0,0,-10);


	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogWarning("There is no player!");
        }
	}
	
	// Update is called once per frame
	void Update () {


        bool ghostIsAlive = false; //Once ghost mode exists, use this variable to follow the ghost.

        if (!ghostIsAlive)
        {
            transform.position = player.transform.position + offset;
        }
	}
}
