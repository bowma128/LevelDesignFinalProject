using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public bool active = false;
    public bool isTimer = false;
    public float length = 0;

    private float timer;

    public Material inactiveMaterial;
    public Material activeMaterial;



	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().sharedMaterial = inactiveMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		if (active && isTimer)
        {
            timer -= Time.deltaTime;
            if (timer<0)
            {
                active = false;
                GetComponent<Renderer>().sharedMaterial = inactiveMaterial;
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Player")
        {
            active = true;
            GetComponent<Renderer>().sharedMaterial = activeMaterial;
            if (isTimer)
            {
                timer = length;
            }
        }
    }
}
