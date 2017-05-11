using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ghostTimerController : MonoBehaviour {

    public RectTransform bar;

	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("Player");
        GameObject ghost = GameObject.Find("Ghost");
        if (ghost != null)
        {
            //If we can find a ghost, we must be in ghost mode.
            this.GetComponent<Image>().enabled = true;
            bar.GetComponent<Image>().enabled = true;
            float amount = ghost.GetComponent<GhostController>().timeLeft / player.GetComponent<GhostController>().defaultTime;
            bar.localScale = new Vector3(amount, 1, 1);
        } else
        {
            //Don't show the timer bar.
            this.GetComponent<Image>().enabled = false;
            bar.GetComponent<Image>().enabled = false;
        }
	}
}
