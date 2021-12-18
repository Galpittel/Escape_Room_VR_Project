using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour
{
    public Text rankingText;
    void Start()
    {

        Load_RankingData_From_CSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Load_RankingData_From_CSV()
    {
        //int prevUserId = PlayerPrefs.GetInt("UserId", 0); //If no Int of this name exists, the default is 0.
        //PlayerPrefs.SetInt("UserId", prevUserId + 1);
        string resulted_ranking = string.Empty;
        string path = System.IO.Path.GetFullPath("Assets\\OurLogs\\log.csv");
        StreamReader strReader = new StreamReader(path);
        bool endOfFile = false;
        string data_String = string.Empty;
        while (!endOfFile)
        {
            data_String = strReader.ReadLine();
            if(data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(',');
            Debug.Log(data_values[0].ToString() + " " + data_values[1].ToString());
            resulted_ranking += "User " + data_values[0].ToString() + " : " + data_values[1].ToString() + "\r\n";
        }
        rankingText.text = resulted_ranking;
    }
    public void LoadFirstRoom()
    {
        Invoke("LoadRoom", 2);
    }
    public void LoadRoom()
    {
        SceneManager.LoadScene("FirstRoom");
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }
}
