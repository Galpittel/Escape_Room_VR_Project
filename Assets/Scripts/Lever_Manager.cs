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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isCorrect && !doorUnlocked && ourLever.transform.eulerAngles.x < 310f && ourLever.transform.eulerAngles.x > 20f)
        {
            doorUnlocked = true;
            ourText.text = "!!!!!";
            finalDoorAnimator.SetTrigger("OpenLastDoor");
        }
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
