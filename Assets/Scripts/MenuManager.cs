using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private Animator start_menu_animator;
    //public Button start_btn;
    //public Button exit_btn;
    //public Button leaderBoard_btn;
    //public Button flip_btn;
    public GameObject start_btn;
    public GameObject exit_btn;
    public GameObject leaderBoard_btn;
    public GameObject flip_btn;
    public GameObject leaderBoardTitle;
    public GameObject rankingText;
    public GameObject gameTitle;
    private AudioSource flip_sound;
    public Button button_Leaderboard;
    public Button button_flipBack;
    // Start is called before the first frame update
    void Start()
    {
        start_menu_animator = gameObject.GetComponent<Animator>();
        flip_sound = gameObject.GetComponent<AudioSource>();
        //ActivateButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rotate_Menu()
    {
        start_menu_animator.SetTrigger("Rotate");
    }
    public void Rotate_Back_Menu()
    {
        start_menu_animator.SetTrigger("RotateBack");
    }
    public void DisableFrontButtons() //After First Flip
    {
        //start_btn.SetActive(false);
        //exit_btn.SetActive(false);
        //leaderBoard_btn.enable(false);
        //flip_btn.SetActive(true);

        //leaderBoardTitle.SetActive(true);
        //rankingText.SetActive(true);
        //start_btn.enabled = false;
        //exit_btn.enabled = false;
        //leaderBoard_btn.enabled = false;
        //flip_btn.enabled = true;

        //Previous Solution - 12.12.21 - using fade material
        //leaderBoardTitle.SetActive(true);
        //rankingText.SetActive(true);
        //flip_btn.SetActive(true);


        button_Leaderboard.enabled = false;
        button_flipBack.enabled = true;
        Invoke("my_Front_Disable", 1.5f);
        

    }
    private void my_Front_Disable()
    {
        //New Change - after removing fade material
        leaderBoardTitle.SetActive(true);
        rankingText.SetActive(true);
        flip_btn.SetActive(true);

        gameTitle.SetActive(false);
        start_btn.SetActive(false);
        exit_btn.SetActive(false);
        leaderBoard_btn.SetActive(false);
        //
    }
    public void ActivateFrontButtons() //After Second flip
    {
        //leaderBoardTitle.SetActive(false);
        //rankingText.SetActive(false);
        //start_btn.enabled = true;
        //exit_btn.enabled = true;
        //leaderBoard_btn.enabled = true;
        //flip_btn.enabled = false;


        //Previous Solution - 12.12.21 - using fade material
        //start_btn.SetActive(true);
        //exit_btn.SetActive(true);
        //leaderBoard_btn.SetActive(true);

        button_flipBack.enabled = false;
        button_Leaderboard.enabled = true;
        Invoke("my_Activate_Front", 1.5f);
    }
    private void my_Activate_Front()
    {
        //New Change - after removing fade material
        gameTitle.SetActive(true);
        start_btn.SetActive(true);
        exit_btn.SetActive(true);
        leaderBoard_btn.SetActive(true);

        leaderBoardTitle.SetActive(false);
        rankingText.SetActive(false);
        flip_btn.SetActive(false);
        
    }
    public void playFlipSound()
    {
        flip_sound.Play();
        //flip_sound.
    }
}
