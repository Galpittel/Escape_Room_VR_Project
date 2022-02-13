using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad_Enabler : MonoBehaviour
{

    public GameObject right_hand_base;
    public GameObject left_hand_base;

    void Update()
    {
        if (Mathf.Sqrt(Mathf.Pow(this.transform.position.x - right_hand_base.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - right_hand_base.transform.position.y, 2) + Mathf.Pow(this.transform.position.z - right_hand_base.transform.position.z, 2)) < 1f)
        {
            right_hand_base.GetComponent<SphereCollider>().isTrigger = false;
        }
        else
        {
            right_hand_base.GetComponent<SphereCollider>().isTrigger = true;
        }

        if (Mathf.Sqrt(Mathf.Pow(this.transform.position.x - left_hand_base.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - left_hand_base.transform.position.y, 2) + Mathf.Pow(this.transform.position.z - left_hand_base.transform.position.z, 2)) < 1f)
        {
            left_hand_base.GetComponent<SphereCollider>().isTrigger = false;
        }
        else
        {
            left_hand_base.GetComponent<SphereCollider>().isTrigger = true;
        }
    }
}
