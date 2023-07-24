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
        ScoreEvents.OnScoreChanged.Add(UpdateText);
    }

    private void OnDisable()
    {
        ScoreEvents.OnScoreChanged.Remove(UpdateText);
    }

    private void UpdateText(int score)
    {
        _text.text = score.ToString();
    }
}
