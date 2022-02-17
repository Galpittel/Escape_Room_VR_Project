using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SOS_Button_Logic : MonoBehaviour
{
    public GameObject phoneBox;
    public GameObject ourPhone;
    public GameObject gameManager;

    private AudioSource room_sound;
    private AudioSource ring_source;
    private AudioSource song_source;

    public Data_Log ourDataLog;
    //public trySO so;
    // Start is called before the first frame update
    void Start()
    {
        ring_source = phoneBox.GetComponent<AudioSource>(); //Get ring sound
        song_source = ourPhone.GetComponent<AudioSource>(); //Get Dolly sound

        room_sound = gameManager.GetComponent<AudioSource>(); //Get Room sound

    }

    // Update is called once per frame
    void Update()
    {
        //if (!ring_source.isPlaying)
        //    room_sound.mute = false;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Skull") && !ring_source.isPlaying && !song_source.isPlaying) //The ring nor the song is playing already
        {
            //Mission 2 completed
            ourDataLog.trial["riddle2"] = (Time.time - ourDataLog.startSceneTime).ToString();
            //room_sound.mute = true;
            ring_source.Play();
            ourPhone.GetComponent<XRGrabInteractable>().enabled = true;
        }

    }
}
