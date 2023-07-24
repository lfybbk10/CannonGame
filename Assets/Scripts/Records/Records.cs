using System;
using System.Collections.Generic;
using UnityEngine;


public class Records : MonoBehaviour
{
    public RecordList recordList;

    private int _maxLength = 5;

    private const string prefsName = "results";

    public static Records instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        
        DontDestroyOnLoad(this);
        Load();
    }

    private void OnEnable()
    {
        ScoreEvents.OnScoreSaved.Add(AddNewScore);
    }
    
    private void OnDisable()
    {
        ScoreEvents.OnScoreSaved.Add(AddNewScore);
    }

    private void AddNewScore(int result)
    {
        if (recordList.Records.Count < _maxLength)
        {
            recordList.Records.Add(result);
            recordList.Records.Sort();
            recordList.Records.Reverse();
            Save();
            return;
        }
            
        for (int i = 0; i < recordList.Records.Count; i++)
        {
            if (result > recordList.Records[i])
            {
                recordList.Records.Insert(i,result);
                recordList.Records.RemoveAt(_maxLength);
                break;
            }
        }
        recordList.Records.Sort();
        recordList.Records.Reverse();
        Save();
    }

    private void Load() => JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(prefsName), recordList);
    
    private void Save() => PlayerPrefs.SetString(prefsName,JsonUtility.ToJson(recordList));

    private void OnApplicationQuit() => Save();
}
