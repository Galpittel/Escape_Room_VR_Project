using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] lever_arr;
    [HideInInspector]
    public bool isCorrect = true;
    public Text ourText;
    public GameObject ourLever;
    public Animator finalDoorAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCorrect && ourLever.transform.rotation.x < -50f)
        {
            ourText.text = "!!!!!";
            finalDoorAnimator.SetTrigger("OpenLastDoor");
        }
    }
    public void validate()
    {
        bool boolChecker = true;
        foreach (GameObject lever in lever_arr)
        {
            //isCorrect = isCorrect && lever.GetComponent<Check_Lever_Input>().CheckAns();
            boolChecker = boolChecker && lever.GetComponent<Check_Lever_Input>().CheckAns();
            
        }
        isCorrect = boolChecker;
        //ourText.text = isCorrect.ToString();

        if (isCorrect)
        {
            ourText.text = "YES";
        }


    }
}
