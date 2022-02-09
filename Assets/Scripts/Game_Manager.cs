using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public GameObject[] teleports;

    // Start is called before the first frame update
    void Start()
    {
        //if (teleports == null)
        //{
        //    teleports = GameObject.FindGameObjectsWithTag("NewTeleport");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTeleports()
    {
        Invoke("ShowTeleportsHelper", 1.5f);
    }

    private void ShowTeleportsHelper()
    {
        foreach (GameObject tele in teleports)
        {
            tele.SetActive(true);
        }
    }
}
