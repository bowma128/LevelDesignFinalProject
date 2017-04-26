using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRotationController : MonoBehaviour {

    public LogicController logic;

    public bool active;
    private bool wasActive;

    private Quaternion startRotation;
    private Quaternion secondRotation;

    public Vector3 rotation;

	// Use this for initialization
	void Start () {
        startRotation = transform.rotation;
        secondRotation = Quaternion.Euler(rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (logic.active && !wasActive)
        {
            active = true;
            transform.rotation = secondRotation;
        }
        if (!logic.active && wasActive)
        {
            active = false;
            transform.rotation = startRotation;
        }
        wasActive = active;
	}
}
