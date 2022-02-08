using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Key_Interactions : MonoBehaviour
{
    public GameObject key_hole;
    public Animator door_animator;
    public GameObject spare_key;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.Equals(key_hole))
    //    {
    //        door_animator.SetTrigger("OpenDoor");
    //        //XRGrabInteractable.Destroy(this);
    //        Destroy(this.GetComponent<XRGrabInteractable>());
    //        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
    //        this.transform.position = new Vector3(-14.25f, 14.89f, 0.54f);
    //        this.transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, -90f));
    //        this.transform.SetParent(key_hole.transform);

    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(key_hole))
        {
            this.gameObject.SetActive(false);
            spare_key.SetActive(true);
            door_animator.SetTrigger("OpenDoor");
            //XRGrabInteractable.Destroy(this);
            //Destroy(this.GetComponent<XRGrabInteractable>());
            //this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            //this.transform.position = new Vector3(-14.25f, 14.89f, 0.54f);
            //this.transform.rotation = Quaternion.Euler(new Vector3(90f, 0f, -90f));
            //this.transform.SetParent(key_hole.transform);

        }
    }

    public void EnableIsTrigger()
    {
        this.gameObject.GetComponent<MeshCollider>().isTrigger = true;
    }

    public void DisableIsTrigger()
    {
        this.gameObject.GetComponent<MeshCollider>().isTrigger = false;
    }
}
