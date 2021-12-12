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
    // Start is called before the first frame update
    void Start()
    {
        start_menu_animator = gameObject.GetComponent<Animator>();
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
    public void DisableButtons() //After First Flip
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

        leaderBoardTitle.SetActive(true);
        rankingText.SetActive(true);
        flip_btn.SetActive(true);
        Invoke("my_Disable", 1.5f);
        

    }
    public void my_Disable()
    {
        start_btn.SetActive(false);
        exit_btn.SetActive(false);
        leaderBoard_btn.SetActive(false);
    }
    public void ActivateButtons() //After Second flip
    {
        //leaderBoardTitle.SetActive(false);
        //rankingText.SetActive(false);
        //start_btn.enabled = true;
        //exit_btn.enabled = true;
        //leaderBoard_btn.enabled = true;
        //flip_btn.enabled = false;

        start_btn.SetActive(true);
        exit_btn.SetActive(true);
        leaderBoard_btn.SetActive(true);
        Invoke("my_Disable2", 1.5f);
    }
    public void my_Disable2()
    {
        leaderBoardTitle.SetActive(false);
        rankingText.SetActive(false);
        flip_btn.SetActive(false);
        
    }
}
