using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingController : MonoBehaviour
{

    public LogicController logic1;

    // Initial Position is where user places Game Object, and position one and two are the 
    // two points the platform heads to. It then forms a loop by going back to position one.
    private Vector3 initialPos;
    public Vector3 positionOne;
    public Vector3 positionTwo;


    // If Ali wants to have the platform stick to its final destination and be a one time thing (NOT RETURN TO HOME BASE)
    public bool isStick = false;

    // These variables let me know where platform is
    private bool reachedOne = false;
    private bool reachedTwo = false;
    private bool hasTwo = false;
    private Vector3 zero;

    // Platform Speed
    public float speed;

    public Vector3 delta;

    // Use this for initialization
    void Start()
    {
        initialPos = transform.position;
        if (!V3Equal(positionTwo, zero))
        {
            hasTwo = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPosition = transform.position;
        // If true, move platform to specified positions
        if (logic1.active)
        {
            // Turn on switch when I reach first point
            if (V3Equal(transform.position, positionOne)) {
                reachedOne = true;
            }
            // Turn on switch when I reach second point
            if (V3Equal(transform.position, positionTwo)) {
                reachedTwo = true;
            }
            // If I am at the starting position, continue looping to position one and two by turning their switches off
            if (V3Equal(transform.position, initialPos))
            {
                reachedOne = false;
                reachedTwo = false;
            }

            // If I have not reached position one, head over.
            if (reachedOne == false)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, positionOne, step);
            }
            else if (reachedTwo == false && hasTwo)
            {         // I’ve reached posOne. If I’ve not reached posTwo, (if it is nonzero), head over.
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, positionTwo, step);
            }
            else if (isStick == false)
            {                       // I’ve reached posOne and posTwo (if it is nonzero). Now head back in a triangle to initialPos (if !isStick).
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, initialPos, step);
            }
        }
        else
        {                                                  // The logic controller is false, so head back to initial position.
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, initialPos, step);
        }
        delta = transform.position - oldPosition;


    }

    // This is a function I found online to compare two Vector3 objects
    public bool V3Equal(Vector3 a, Vector3 b)
    {
        return Vector3.SqrMagnitude(a - b) < 0.0001;
    }

    //check if the player is standing on the platform. If they are, move them with the platform according to delta.
    public void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            MovementController mc = col.GetComponent<MovementController>();
            mc.moveOffset = delta;
        }
    }
}
