using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooserController : MonoBehaviour {

    public List<GameObject> choices;
    public Vector3 offset = new Vector3(-100, 0, 0);
    public float triggerValue = .5f;
    public int currentIndex = 0;
    private float oldVertical;

	// Use this for initialization
	void Start () {
		foreach(GameObject g in choices)
        {
            if (g.GetComponent<optionController>() == null)
            {
                Debug.LogWarning("No option controller on "+ g.name);
            }
        }
	}
	
	// Update is called once per frame
    void Update () { }
	void OnGUI () {


        if (Input.GetAxisRaw("Jump") > triggerValue)
        {
            choices[currentIndex].GetComponent<optionController>().choose();
        }

        float vert = Input.GetAxisRaw("Vertical");
        if (vert>=triggerValue && oldVertical<triggerValue)
        {
            //If the value just went upward (rising edge), subtract 1.
            currentIndex--;
            //If the value gets too low, put it back in range.
            if (currentIndex == -1)
            {
                currentIndex = choices.Count-1;
            }
        } else if (vert<= (-1*triggerValue) && oldVertical> (-1*triggerValue))
        {
            currentIndex++;
            if(currentIndex==choices.Count)
            {
                currentIndex = 0;
            }
        }

        GameObject g = choices[currentIndex];
        transform.position = g.transform.position + offset;


        oldVertical = vert;
    }
}
