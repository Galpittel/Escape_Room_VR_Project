using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class Table_Riddle_Manager : MonoBehaviour
{
    private int current_weight;
    private int goal_weight = 100;
    public Animator bridgeAnimator;
    
    private XRBaseInteractable current_interactable2;

    private XRSocketInteractor current_socket;

    public Obj_Data SO;
    private string currentTag;

    public Text our_UI; 

    private Dictionary<string, int> weight_dict = new Dictionary<string, int>() {
        { "Crown", 50 }, { "Diamond", 25 }, { "Bottle", 10 }, { "Bone", 5 }, { "Wine_Glass", 20 }
    };

    //public GameObject[] go_arr; //GameObject array
    //private XRSocketInteractor socket_arr;

    // Start is called before the first frame update
    void Start()
    {
        SO.Init();
        current_socket = GetComponent<XRSocketInteractor>();
        //for(int i=0;i<go_arr.Length;i++)
        //{
        //    socket_arr[i] = go_arr[i].GetComponent<XRSocketInteractor>();
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addWeight()
    {
        //current_interactable = this.GetComponent<XRSocketInteractor>();
        current_interactable2 = this.GetComponent<XRSocketInteractor>().selectTarget;
        if (current_interactable2 != null)
        {
            currentTag = current_interactable2.tag;
            SO.updateWeight(SO.weight_dict[currentTag]);
        }
        //Debug.Log(current_interactable2);
        our_UI.text = SO.currentWeight.ToString();
        checkGoal();
    }

    public void removeWeight()
    {

        //current_interactable2 = this.GetComponent<XRSocketInteractor>().selectTarget;

        if (current_interactable2 != null)
        {
            currentTag = current_interactable2.tag;
            SO.removeWeight(SO.weight_dict[currentTag]);
        }

        current_interactable2 = this.GetComponent<XRSocketInteractor>().selectTarget;

        our_UI.text = SO.currentWeight.ToString();


        //our_UI.text = "HERE";

        checkGoal();


    }
    private void checkGoal()
    {
        if (SO.currentWeight == SO.goalWeight && bridgeAnimator!=null)
        {
            
            bridgeAnimator.SetTrigger("Bridge_anim");
            Debug.Log("EQUAL");
        }
    }

    
    
}
