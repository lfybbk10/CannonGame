using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UICountEnemies : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Events.OnChangeEnemiesCount.Add(UpdateText);
    }

    private void OnDisable()
    {
        Events.OnChangeEnemiesCount.Remove(UpdateText);
    }

    private void UpdateText(int count)
    {
        _text.text = "Количество врагов: " + count;
    }
}
