using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreKeeper : ScriptableObject
{
    //[HideInInspector]
    public string ppid;

    [HideInInspector]
    public Dictionary<string, string> sessionInfo;
    



    void Awake()
    {
        //Initialize("ori", null);

        //outputFolder = Application.dataPath + "/StreamingAssets" + "/output";
        //if (!Directory.Exists(outputFolder))
        //{
        //    Directory.CreateDirectory(outputFolder);
        //}
    }

    public void Initialize(string participantID, List<string> customHeader)
    {
        ppid = participantID;
        //header = customHeader;
        //InitHeader();
        //InitDict();
        //output = new List<string>();
        //output.Add(string.Join(",", header.ToArray()));
        //dataOutputPath = outputFolder + "/" + participantID + ".csv";
    }

    public void AddScore(string level)
    {
        sessionInfo[level] = Time.time.ToString();
    }
}
