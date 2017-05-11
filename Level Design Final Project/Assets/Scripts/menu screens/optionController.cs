using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionController : MonoBehaviour {

    public string level;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void choose()
    {
        if (level != "_EXIT_")
        {
           SceneManager.LoadScene(level);
           
        } else
        {
            Application.Quit();
        }
    }
}
