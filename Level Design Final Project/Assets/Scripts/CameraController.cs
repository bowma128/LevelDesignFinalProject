using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;
    public Vector3 offset = new Vector3(0,0,-10);

    public bool changePerspective = false;

    private float size;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogWarning("There is no player!");
        }
        size = this.GetComponent<Camera>().orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
        
        bool ghostIsAlive = GameObject.Find("Ghost") != null; //Once ghost mode exists, use this variable to follow the ghost.

        if (!ghostIsAlive)
        {
            //this.GetComponent<Camera>().orthographicSize = size;
            transform.position = player.transform.position + offset;
            if (changePerspective)
            {
                this.GetComponent<Camera>().orthographic = true; //Uncomment this line and the one below to be in perspective rendering in ghost mode.
            }
        } else
        {
            GameObject ghost = GameObject.Find("Ghost");
            Vector3 camVector = ghost.transform.position;//(ghost.transform.position + player.transform.position) * .5f;
            //this.GetComponent<Camera>().orthographicSize = 8;
            transform.position = camVector + offset;
            if (changePerspective)
            {
                this.GetComponent<Camera>().orthographic = false;
            }
        }
	}
}
