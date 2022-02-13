using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using CameraFading;

public class Game_Manager : MonoBehaviour
{
    public GameObject[] teleports;
    public ScoreKeeper score_keeper;

    // Start is called before the first frame update
    void Start()
    {
        //score_keeper.Initialize("moshe", null);
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

    //public void updateScore(string level)
    //{
    //    score_keeper.AddScore(level);
    //}

    public void LoadSecondRoom()
    {
        Invoke("LoadRoom", 2f);
    }

    public void LoadRoom()
    {
        SceneManager.LoadScene("SecondRoom");
    }

    public void FadeCameraTransition()
    {

        CameraFade.Out(2f);
        CameraFade.Alpha = 1f;
    }

}
