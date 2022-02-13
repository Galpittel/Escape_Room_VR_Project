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
