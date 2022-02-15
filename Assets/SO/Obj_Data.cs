using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Obj_Data : ScriptableObject
{
    public Dictionary<string, int> weight_dict = new Dictionary<string, int>() {
        { "Crown", 50 }, { "Diamond", 100 }, { "Bottle", 5 }, { "Hammer", 25 }, { "WineGlass", 30 }, {"Candle", 10}
    };

    public int currentWeight;
    public int goalWeight = 250;

    public bool goalReached = false;
    void Awake()
    {

    }
    public void Init()
    {
        currentWeight = 0;

    }
    public void updateWeight(int weight)
    {
        currentWeight += weight;
    }

}
