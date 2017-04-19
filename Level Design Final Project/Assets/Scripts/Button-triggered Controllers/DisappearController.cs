using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearController : MonoBehaviour {

    public LogicController logic;

    private bool wasActive = false;

    public bool active = false;
    // Use this for initialization
    void Start()
    {
        if (logic == null)
        {
            Debug.LogWarning("Button not set for object " + this.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!wasActive && logic.active)
        {
            active = true;
            activate();
        }
        if (active)
        {
            //Put all code that has to run while the button is active here.
        }
        wasActive = logic.active;
    }

    void activate()
    {
        //Put code to run when activated here.
        Destroy(this.gameObject);
    }
}