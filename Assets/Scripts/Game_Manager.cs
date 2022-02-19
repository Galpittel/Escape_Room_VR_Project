using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using CameraFading;

public class Game_Manager : MonoBehaviour
{
    public GameObject[] teleports;
    public Data_Log ourDataLog;
    public GameObject editorButtons;
    public Animator[] ourEditorAnimators;

    void Awake()
    {
        #if UNITY_EDITOR
                foreach (Animator a in ourEditorAnimators)
                {
                    a.enabled = true;
                }
                editorButtons.SetActive(true);
        #endif


    }
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_EDITOR
                editorButtons.SetActive(true);
        #endif
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
