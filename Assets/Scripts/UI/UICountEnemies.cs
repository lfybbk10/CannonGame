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
        EnemyEvents.OnChangeEnemiesCount.Add(UpdateText);
    }

    private void OnDisable()
    {
        EnemyEvents.OnChangeEnemiesCount.Remove(UpdateText);
    }

    private void UpdateText(int count)
    {
        _text.text = "Количество врагов: " + count;
    }
}
