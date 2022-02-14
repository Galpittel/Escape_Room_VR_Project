using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_handler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGravity()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }

}
