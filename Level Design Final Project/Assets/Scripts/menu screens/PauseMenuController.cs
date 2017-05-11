using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    private float oldValue = 0;

    public bool isPaused = false;

    public GameObject menu;

	// Use this for initialization
	void Start () {
		if (menu == null)
        {
            Debug.Log("There is no menu attached to " + transform.name);
        }
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnGUI()
    {
        float value = Input.GetAxisRaw("Pause");
        if (value == 1 && oldValue == 0)
        {
            if (Time.timeScale == 0)
            {
                isPaused = false;
                Time.timeScale = 1;

                menu.SetActive(false);
            }
            else
            {
                isPaused = true;
                Time.timeScale = 0;
                menu.SetActive(true);
            }
        }
        oldValue = value;
    }
}
