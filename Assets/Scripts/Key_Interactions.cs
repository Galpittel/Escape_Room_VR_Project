using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Key_Interactions : MonoBehaviour
{
    public GameObject first_key_hole;
    public GameObject second_key_hole;
    public GameObject spare_key;
    public GameObject our_door;
    public GameObject gameManager;
    public AudioClip key_sound;


    static int s_IDMax = 0;

    int m_ID;

    void Awake()
    {
        m_ID = s_IDMax;
        s_IDMax++;
    }

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
        if (other.gameObject.Equals(first_key_hole))
        {
            this.gameObject.SetActive(false);
            spare_key.SetActive(true);
            our_door.GetComponent<Animator>().SetTrigger("OpenDoor");
            our_door.GetComponent<AudioSource>().Play();


            //Finished Task 1

            //We need to animate Teleportation anchors, and write to file (how?) the time of completion of task 1

            gameManager.GetComponent<Game_Manager>().ShowTeleports();


            //gameManager.GetComponent<Game_Manager>().updateScore("LEVEL_NAME");
        }

        if (other.gameObject.Equals(second_key_hole))
        {
            this.gameObject.SetActive(false);
            spare_key.SetActive(true);
            our_door.GetComponent<Animator>().SetTrigger("SecondDoor");
            our_door.GetComponent<AudioSource>().Play();


            //Finished Task 1

            //We need to animate Teleportation anchors, and write to file (how?) the time of completion of task 1

            gameManager.GetComponent<Game_Manager>().ShowTeleports();
        }


        //if(other.gameObject)
    }

    private void OnCollisionEnter(Collision other)
    {
        if (Time.timeSinceLevelLoad < 1.0f)
            return;


        SFXPlayer.Instance.PlaySFX(key_sound, other.contacts[0].point, new SFXPlayer.PlayParameters()
        {
            Volume = 1.0f,
            Pitch = Random.Range(0.8f, 1.2f),
            SourceID = m_ID
        }, 0.5f);

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
