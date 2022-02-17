using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Check_Lever_Input : MonoBehaviour
{
    public Text ourText;
    public int correctAns;
    public int current_step = 0;
    public GameObject Lever_Manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCurrentStep()
    {
        return current_step;
    }
    public void ourcheckFunc(int step)
    {
        current_step = step;
        ourText.text = step.ToString();
        Lever_Manager.GetComponent<Lever_Manager>().validate();
    }

    public bool CheckAns()
    {
        return current_step == correctAns;
    }
}
