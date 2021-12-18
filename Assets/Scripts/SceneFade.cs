using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CameraFading;

public class SceneFade : MonoBehaviour
{
    void Awake()
    {
        CameraFade.In(2f);
        CameraFade.Alpha = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
