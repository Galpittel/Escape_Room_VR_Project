using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] lever_arr;
    [HideInInspector]
    public bool isCorrect = false;
    public Text ourText;
    public GameObject ourLever;
    public Animator finalDoorAnimator;
    private bool doorUnlocked = false;
    public AudioSource lastDoorSound;
    public AudioSource victoryMusic;
    public AudioSource backgroundMusic;
    public GameObject finalTeleport;
    public Data_Log ourDataLog;
    public Text finishText;
    void Start()
    {
        isCorrect = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isCorrect && !doorUnlocked && ourLever.transform.eulerAngles.x < 310f && ourLever.transform.eulerAngles.x > 20f)
        {
            //Mission 6 completed
            float endGameTime = Time.time - ourDataLog.startSceneTime;
            ourDataLog.trial["riddle6"] = endGameTime.ToString();
            doorUnlocked = true;
            finalDoorAnimator.SetTrigger("OpenLastDoor");
            finalTeleport.SetActive(true);
            backgroundMusic.Stop();
            lastDoorSound.Play();
            Invoke("PlayVictoryMusic", 1.5f);
            finishText.text += " " + ((int)(endGameTime/60)).ToString() + " minutes and " + ((int)(endGameTime%60)).ToString() + " seconds!";
            //Write to file
            ourDataLog.WriteToFile();
        }
    }
    private void PlayVictoryMusic()
    {
        victoryMusic.Play();
    }
    public void validate()
    {
        bool boolChecker = true;
        foreach (GameObject lever in lever_arr)
        {
            boolChecker = boolChecker && lever.GetComponent<Check_Lever_Input>().CheckAns();
            
        }
        isCorrect = boolChecker;

        if (isCorrect)
        {
            ourText.text = "YES";
        }


    }
}
