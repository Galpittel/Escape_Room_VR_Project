using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private Animator start_menu_animator;
    public Button start_btn;
    public Button exit_btn;
    public Button leaderBoard_btn;
    public Button flip_btn;
    // Start is called before the first frame update
    void Start()
    {
        start_menu_animator = gameObject.GetComponent<Animator>();
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
    public void DisableButtons()
    {
        //start_btn.SetActive(false);
        //exit_btn.SetActive(false);
        //leaderBoard_btn.enable(false);
        //flip_btn.SetActive(true);
        start_btn.enabled = false;
        exit_btn.enabled = false;
        leaderBoard_btn.enabled = false;
        flip_btn.enabled = true;

    }
    //public void my_Disable()
    //{
    //    start_btn.SetActive(false);
    //    exit_btn.SetActive(false);
    //    leaderBoard_btn.SetActive(false);
    //    flip_btn.SetActive(true);
    //}
    public void ActivateButtons()
    {
        start_btn.enabled = true;
        exit_btn.enabled = true;
        leaderBoard_btn.enabled = true;
        flip_btn.enabled = false;
    }
}
