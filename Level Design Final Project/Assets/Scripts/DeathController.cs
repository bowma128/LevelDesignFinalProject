using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour {


    public GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gm == null)
        {
            Debug.LogWarning("There is no GameManager named\"GameManager\" in the scene!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.name == "Ghost")
        {
            col.GetComponent<GhostController>().killGhost();
            gm.updateObjects(false);
        } if (col.transform.name == "Player")
        {
            col.transform.position = gm.current_checkpoint;
            gm.loseLife();
        }

    }
}
