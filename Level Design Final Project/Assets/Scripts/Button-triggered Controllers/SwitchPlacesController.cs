using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlacesController : MonoBehaviour {

    public LogicController logic;

    private bool wasActive = false;
    public bool active = false;

    private Vector3 firstPosition;
    public Vector3 secondPosition;
	// Use this for initialization
	void Start () {
        firstPosition = transform.position;
		if (logic == null)
        {
            Debug.LogWarning("Button not set for object " + this.gameObject.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!wasActive && logic.active)
        {
            active = true;
            transform.position = secondPosition;
        }
        if (wasActive && !logic.active)
        {
            active = false;
            transform.position = firstPosition;
        }
        wasActive = logic.active;
	}
}
