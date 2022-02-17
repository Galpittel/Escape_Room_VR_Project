using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Init_Manager : MonoBehaviour
{
    public Data_Log ourDataLog;
    void Awake()
    {
        ourDataLog.Init();

    }
}
