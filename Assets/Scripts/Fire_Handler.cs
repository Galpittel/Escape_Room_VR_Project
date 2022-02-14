using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Fire_Handler : MonoBehaviour
{
    public GameObject key;
    public ParticleSystem[] webFire;
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
        //if (other.tag.Equals("Fire"))
        //{
        //    this.GetComponent<ParticleSystem>().Play();
        //}
        Debug.Log("TAL");
        if (other.tag.Equals("SpiderWeb"))
        {
            foreach (ParticleSystem fire in webFire)
            {
                fire.Play();
            }
            Invoke("Delay", 1.5f);
        }

        void Delay()
        {
            other.SetActive(false);
            key.GetComponent<Rigidbody>().useGravity = true;
            key.GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

}
