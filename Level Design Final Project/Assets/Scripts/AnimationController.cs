using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        myAnimator = GetComponent<Animtor>();
		
	}
	
	// Update is called once per frame
	void Update () {

        myAnimator.SetFloat ("VSpeed, Input.GetAxis ("Vertical");
		
	}
}
