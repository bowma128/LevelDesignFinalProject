using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider col){
		//Check for player
		if(col.tag == "Player"){
			//make player child
			col.gameObject.transform.parent = this.gameObject.transform;
		}
	}

	void OnTriggerExit(Collider col){
		//Check for player
		if(col.tag == "Player"){
			//make player child
			col.gameObject.transform.parent = null;
		}
	}
}
