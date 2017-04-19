using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum type { pass, and, or, xor, not }

public class LogicController : MonoBehaviour {
    public type gateType = type.pass;
    public ButtonController button1;
    public ButtonController button2;

    public bool active;
	// Use this for initialization
	void Start () {
        if (button1 == null)
        {
            Debug.LogWarning("There needs to be a button controller for " + gameObject.name);
        } if (gateType != type.pass && gateType != type.not)
        {
            if (button1 == null && button2 == null)
            {
                Debug.LogWarning("There need to be 2 button controllers for " + gameObject.name);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(gateType == type.pass)
        {
            active = button1.active;
        } else if (gateType == type.and)
        {
            active = button1.active && button2.active;
        } else if (gateType == type.or)
        {
            active = button1.active || button2.active;
        } else if (gateType == type.xor)
        {
            active = button1.active != button2.active;
        } else if (gateType == type.not) {
            active = !button1.active;
        }
	}
}
