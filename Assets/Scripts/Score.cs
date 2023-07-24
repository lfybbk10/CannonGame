using System;
using UnityEngine;


public class Score : MonoBehaviour
{
    [SerializeField] private int _additionValue;
    private int _value;

    private void OnEnable()
    {
        Events.OnEnemyDestroyed.Add(AddScore);
        Events.OnLose.Add(SendScore);
    }

    private void OnDisable()
    {
        Events.OnEnemyDestroyed.Remove(AddScore);
        Events.OnLose.Remove(SendScore);
    }

    private void AddScore()
    {
        _value += _additionValue;
        Events.OnScoreChanged.Publish(_value);
    }
    
    
    private void SendScore()
    {
        Events.OnScoreSaved.Publish(_value);
    }

    public int GetValue() => _value;
}
