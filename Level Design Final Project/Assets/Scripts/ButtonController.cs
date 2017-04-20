using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum buttonType { Permanent, Timer, Switch, Hold};

public class ButtonController : MonoBehaviour {

    public buttonType type = buttonType.Permanent;
    public bool active = false;
    private bool wasActive = false;

    public float length = 0;

    private float timer;

    private bool playerInField = false;
    private bool playerWasInField = false;

    public Material inactiveMaterial;
    public Material activeMaterial;



	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().sharedMaterial = inactiveMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		if (active && type == buttonType.Timer)
        {
            timer -= Time.deltaTime;
            if (timer<0)
            {
                active = false;
            }
        }
        if (playerInField && !playerWasInField)
        {
            //The player has just entered the button field.
            if (type == buttonType.Hold)
            {
                active = true;
            } else if (type == buttonType.Permanent)
            {
                active = true;
            } else if (type == buttonType.Switch)
            {
                active = !active;
            } else if (type == buttonType.Timer && !active)
            {
                //The player should have to wait for the button to reset before resetting the timer.
                active = true;
                timer = length;
            }
        }
        if (!playerInField && playerWasInField)
        {
            //The player has just left the button field.
            if (type == buttonType.Hold)
            {
                active = false;
            } 
        }
        playerWasInField = playerInField;
        
        updateMaterial();
	}

    void updateMaterial()
    {
        if (wasActive && !active)
        {
            GetComponent<Renderer>().sharedMaterial = inactiveMaterial;
        }
        if (!wasActive && active)
        {
            GetComponent<Renderer>().sharedMaterial = activeMaterial;
        }
        wasActive = active;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Player")
        {
            playerInField = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag=="Player")
        {
            playerInField = false;
        }
    }
}
