using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public bool activated = false;

    public Vector3 offset = new Vector3(0, 0, 1);

    public GameManager gm;
	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Player")
        {
            if (!activated)
            {
                activated = true;
                gm.current_checkpoint = transform.position + offset;
            }
        }
    }
}
