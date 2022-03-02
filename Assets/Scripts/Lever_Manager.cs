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
            doorUnlocked = true;
            finalDoorAnimator.SetTrigger("OpenLastDoor");
            finalTeleport.SetActive(true);
            backgroundMusic.Stop();
            lastDoorSound.Play();
            Invoke("PlayVictoryMusic", 1.5f);

            if (ourDataLog.trial != null)
            {
                float endGameTime = Time.time - ourDataLog.startSceneTime;
                ourDataLog.trial["riddle6"] = endGameTime.ToString();
                finishText.text += " " + ((int)(endGameTime / 60)).ToString() + " minutes and " + ((int)(endGameTime % 60)).ToString() + " seconds!";
                //Write to file
                ourDataLog.WriteToFile();

                updatePlayerPrefs(endGameTime);
            }
        }
    }

    private void updatePlayerPrefs(float endTime)
    {
        float thirdPlaceTime = PlayerPrefs.GetFloat("ThirdPlaceTime", 99999f);
        float secondPlaceTime = PlayerPrefs.GetFloat("SecondPlaceTime", 99999f);
        float firstPlaceTime = PlayerPrefs.GetFloat("FirstPlaceTime", 99999f);
        //int currentPPID = ourDataLog.ppid; //Get current player ID
        int currentPPID = PlayerPrefs.GetInt("ppid");

        if (endTime < thirdPlaceTime) //Current player better than third place, replace them
        {
            PlayerPrefs.SetFloat("ThirdPlaceTime", endTime);
            PlayerPrefs.SetInt("ThirdPlaceID", currentPPID);

            if(endTime < secondPlaceTime) //Also better than second place, replace them
            {
                PlayerPrefs.SetFloat("ThirdPlaceTime", secondPlaceTime);
                PlayerPrefs.SetInt("ThirdPlaceID", PlayerPrefs.GetInt("SecondPlaceID"));

                PlayerPrefs.SetFloat("SecondPlaceTime", endTime);
                PlayerPrefs.SetInt("SecondPlaceID", currentPPID);

                if (endTime < firstPlaceTime) //Also better than first place, replace them
                {
                    PlayerPrefs.SetFloat("SecondPlaceTime", firstPlaceTime);
                    PlayerPrefs.SetInt("SecondPlaceID", PlayerPrefs.GetInt("FirstPlaceID"));

                    PlayerPrefs.SetFloat("FirstPlaceTime", endTime);
                    PlayerPrefs.SetInt("FirstPlaceID", currentPPID);
                }
            }
            
        }
        PlayerPrefs.Save();

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


    }
}
