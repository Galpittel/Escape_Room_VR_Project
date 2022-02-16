using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    public GameObject ourPot;
    private float startGazeTime;
    private bool gaze = false;
    private const float minGazeTime = 1f;
    private bool viewed = false;
    private Vector3 viewPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        viewPos = GetComponent<Camera>().WorldToViewportPoint(ourPot.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            Debug.Log("IT IS IN");
        }
        else
        {
            Debug.Log("IT IS OUT");

        }
        //if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        //{
        //    GameObject go = hit.collider.gameObject;
        //    if(go.name == "Pot_02")
        //    {
        //        //Debug.Log("ORIPPPPP");
        //        //Debug.Log("Gaze: " + gaze);
        //        if (!gaze)
        //        {
        //            startGazeTime = Time.time;
        //            //Debug.Log(startGazeTime);
        //            gaze = true;
        //        }
        //        else
        //        {
        //            //Debug.Log("TIME: ");
        //            //Debug.Log(Time.time - startGazeTime);

        //            if((Time.time - startGazeTime >= minGazeTime) && !viewed)
        //            {
        //                Debug.Log("Viewing POT");
        //                viewed = true;
        //            }
        //        }
        //    }
        //    else //Gazing at another object
        //    {
        //        gaze = false;
        //        Debug.Log("NAME: " + go.name);
        //    }
        //}

        //else //Not gazing at anything
        //{
        //    //Debug.Log("NOT GAZING");
        //}
    }
}
