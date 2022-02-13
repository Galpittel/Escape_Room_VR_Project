using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOS_Button_Logic : MonoBehaviour
{
    public GameObject phoneBox;
    public GameObject ourPhone;

    private AudioSource ring_source;
    private AudioSource song_source;

    //public trySO so;
    // Start is called before the first frame update
    void Start()
    {
        ring_source = phoneBox.GetComponent<AudioSource>(); //Get ring sound
        song_source = ourPhone.GetComponent<AudioSource>(); //Get Dolly sound


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Skull") && !ring_source.isPlaying && !song_source.isPlaying) //The ring nor the song is playing already
        {
            ring_source.Play();
        }

    }
}
