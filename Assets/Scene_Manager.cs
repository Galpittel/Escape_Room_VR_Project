using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFirstRoom()
    {
        Invoke("LoadRoom", 2);
    }
    public void LoadRoom()
    {
        SceneManager.LoadScene("FirstRoom");
    }
}
