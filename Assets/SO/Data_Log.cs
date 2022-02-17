using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu]
public class Data_Log : ScriptableObject
{
    public int ppid; //ParticipantID
    [HideInInspector]
    public Dictionary<string, string> trial; //Will contain ppid, riddleTime1 - riddleTime6, endTime
    List<string> header;
    string dataOutputPath;
    List<string> output;
    [HideInInspector]
    public string outputFolder;
    [HideInInspector]
    public bool trialStarted = false;
    [HideInInspector]
    public float startSceneTime;
    [HideInInspector]
    public float secondSceneStartTime;


    

    void Awake()
    {
        Debug.Log("APP data path: " + Application.dataPath);
        //outputFolder = Application.dataPath + "/StreamingAssets" + "/output";
        outputFolder = Application.persistentDataPath + "/output";
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }
    }


    public void Init()
    {
        trialStarted = true;
        InitHeader();
        InitDict();
        ppid += 1;
        trial["ppid"] = ppid.ToString();
        //ppid = participantID;
        startSceneTime = Time.time;
        //header = customHeader;

        output = new List<string>();
        //output.Add(string.Join(",", header.ToArray()));
        //dataOutputPath = outputFolder + "/" + ppid.ToString() + ".csv";
        dataOutputPath = outputFolder + "/" + "scores" + ".csv";
        //If file exists - don't write the header
        if (!File.Exists(dataOutputPath))
        {
            output.Add(string.Join(",", header.ToArray()));
        }
    }
    private void InitHeader()
    {
        header = new List<string>();
        header.Insert(0, "ppid");
        header.Insert(1, "riddle1");
        header.Insert(2, "riddle2");
        header.Insert(3, "riddle3");
        header.Insert(4, "riddle4");
        header.Insert(5, "riddle5");
        header.Insert(6, "riddle6");
        //header.Insert(7, "endTime");


    }

    private void InitDict()
    {
        trial = new Dictionary<string, string>();
        foreach (string value in header)
        {
            trial.Add(value, "");
        }
    }

    //public void StartTrial()
    //{
    //    trialStarted = true;
    //    ppid += 1;
    //    InitDict();
    //    trial["ppid"] = ppid.ToString();
    //    startTime = Time.time;
    //}


    //private void OnApplicationQuit()
    //{
    //    Debug.Log("APP QUIT");
    //    output.Add(FormatTrialData());
    //    if (output != null && dataOutputPath != null)
    //    {
    //        //File.WriteAllLines(dataOutputPath, output.ToArray());
    //        //NEW
    //        File.AppendAllLines(dataOutputPath, output.ToArray());
    //        Debug.Log(string.Format("Saved data to {0}.", dataOutputPath));
    //    }
    //    else Debug.LogError("Error saving data - TrialLogger was not initialsed properly");

    //}

    public void WriteToFile()
    {
        output.Add(FormatTrialData());
        if (output != null && dataOutputPath != null)
        {
            File.AppendAllLines(dataOutputPath, output.ToArray());
            Debug.Log(string.Format("Saved data to {0}.", dataOutputPath));
        }
        else Debug.LogError("Error saving data - TrialLogger was not initialsed properly");
    }

    private string FormatTrialData()
    {
        List<string> rowData = new List<string>();
        foreach (string value in header)
        {
            rowData.Add(trial[value]);
        }
        return string.Join(",", rowData.ToArray());
    }
}
