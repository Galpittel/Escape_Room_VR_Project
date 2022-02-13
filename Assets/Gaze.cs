using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    private float startGazeTime;
    private bool gaze = false;
    private const float minGazeTime = 1f;
    private bool viewed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if(go.name == "Pot_01")
            {
                //Debug.Log("ORIPPPPP");
                //Debug.Log("Gaze: " + gaze);
                if (!gaze)
                {
                    startGazeTime = Time.time;
                    //Debug.Log(startGazeTime);
                    gaze = true;
                }
                else
                {
                    //Debug.Log("TIME: ");
                    //Debug.Log(Time.time - startGazeTime);

                    if((Time.time - startGazeTime >= minGazeTime) && !viewed)
                    {
                        Debug.Log("Viewing POT");
                        viewed = true;
                    }
                }
            }
            else //Gazing at another object
            {
                gaze = false;
                //Debug.Log("NAME: " + go.name);
            }
        }

        else //Not gazing at anything
        {

        }
    }
}
