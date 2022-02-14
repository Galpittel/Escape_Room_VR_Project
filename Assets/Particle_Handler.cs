using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Handler : MonoBehaviour
{
    public ParticleSystem[] torchFire;
    public GameObject torchTip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("HERE!");
        if (other.gameObject.Equals(torchTip))
        {
            //this.GetComponent<ParticleSystem>().Play();
            foreach(ParticleSystem fire in torchFire)
            {
                fire.Play();

            }
        }

        //if (other.tag.Equals("SpiderWeb"))
        //{
        //    foreach (ParticleSystem fire in webFire)
        //    {
        //        fire.Play();
        //    }
        //    Invoke("Delay", 1.5f);
        //}
    }
}
