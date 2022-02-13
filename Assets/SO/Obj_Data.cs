using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Obj_Data : ScriptableObject
{
    public Dictionary<string, int> weight_dict = new Dictionary<string, int>() {
        { "Crown", 50 }, { "Diamond", 25 }, { "Bottle", 10 }, { "Bone", 5 }, { "Wine_Glass", 20 }
    };

    public int currentWeight;
    public int goalWeight = 100;

    private GameObject ourBridge;

    private Animator bridgeAnimator;

    void Awake()
    {
        ourBridge = GameObject.Find("Bridge");
        bridgeAnimator = ourBridge.GetComponent<Animator>();
    }
    public void Init()
    {
        currentWeight = 0;

    }
    public void updateWeight(int weight)
    {
        currentWeight += weight;
        Debug.Log("Current Weight is: " + currentWeight);
        //checkGoal();
    }

    public void removeWeight(int weight)
    {
        currentWeight -= weight;
        Debug.Log("Current Weight is: " + currentWeight);
        //checkGoal();
    }

    //private void checkGoal()
    //{
    //    if (currentWeight == goalWeight)
    //    {
    //        bridgeAnimator.SetTrigger("Bridge_anim");
    //        Debug.Log("EQUAL");
    //    }
    //}
}
