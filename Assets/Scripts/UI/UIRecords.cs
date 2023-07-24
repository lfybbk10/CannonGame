using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIRecords : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetRecordsInfo();
    }

    private void SetRecordsInfo()
    {
        var results = Records.instance.recordList.Records;
        for (int i = 0; i < results.Count; i++)
        {
            _text.text += (i + 1) + ". " + results[i]+"\n";
        }
    }
}
