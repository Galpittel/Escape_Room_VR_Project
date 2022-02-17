using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone_handler : MonoBehaviour
{
    public GameObject phone_box;
    private AudioSource ring_source;
    private AudioSource dolly_source;
    public AudioSource backgroundMusic;
    private bool alreadyAnswered = false;
    // Start is called before the first frame update
    void Start()
    {
        ring_source = phone_box.GetComponent<AudioSource>();
        dolly_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void answer_Phone()
    {
        //We grabbed the phone

        //if (ring_source.isPlaying || alreadyAnswered)
        //{
        //    ring_source.Pause();
        //    dolly_source.Play();
        //    alreadyAnswered = true;
        //}

        if (ring_source!=null && dolly_source != null && backgroundMusic != null)
        {

            ring_source.Pause();
            dolly_source.Play();
            backgroundMusic.Pause();
        }

    }

    public void hangUp() //Will be called once phone is returned to socket. Select entered event of PhoneSocket.
    {
        if (dolly_source != null && backgroundMusic != null)
        {
            dolly_source.Pause();
            backgroundMusic.Play();
        }
    }




}
