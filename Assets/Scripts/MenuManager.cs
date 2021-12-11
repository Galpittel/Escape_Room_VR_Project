using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Animator start_menu_animator;
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
}
