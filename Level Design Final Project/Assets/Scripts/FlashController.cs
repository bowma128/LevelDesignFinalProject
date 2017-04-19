using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour {

    public float flashLength = .5f;

    public bool flashNow = false;

    public float timeLeft = 0;

    public bool screenCovered = false;
	// Use this for initialization
	void Start () {
        GetComponent<CanvasRenderer>().SetAlpha(0);
	}
	
    public void flash()
    {
        flashNow = true;
    }

	// Update is called once per frame
	void Update () {
        if (flashNow)
        {
            flashNow = false;
            timeLeft = flashLength;
        }
		if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            float alpha = flashTime(flashLength, flashLength - timeLeft) * 1.5f;
            //Debug.Log(alpha);
            GetComponent<CanvasRenderer>().SetAlpha(alpha);
            if (alpha>1f)
            {
                screenCovered = true;
            } else {
                screenCovered = false;
            }
        }
	}

    float flashTime(float length, float t)
    {
        if (t<length/2f)
        {
            return (2f * t) / length;
        } else
        {
            return 2f - (2f * t / length);
        }
    }
}
