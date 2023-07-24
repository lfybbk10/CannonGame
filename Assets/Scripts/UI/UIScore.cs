using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIScore : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Events.OnScoreChanged.Add(UpdateText);
    }

    private void OnDisable()
    {
        Events.OnScoreChanged.Remove(UpdateText);
    }

    private void UpdateText(int score)
    {
        _text.text = score.ToString();
    }
}
