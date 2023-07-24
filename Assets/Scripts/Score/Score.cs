using System;
using UnityEngine;


public class Score : MonoBehaviour
{
    [SerializeField] private int _additionValue;
    private int _value;

    private void OnEnable()
    {
        EnemyEvents.OnEnemyDestroyed.Add(AddScore);
        ScoreEvents.OnScoreAdded.Add(AddScoreValue);
        GameProgressEvents.OnLose.Add(SendScore);
    }

    private void OnDisable()
    {
        EnemyEvents.OnEnemyDestroyed.Remove(AddScore);
        GameProgressEvents.OnLose.Remove(SendScore);
        ScoreEvents.OnScoreAdded.Remove(AddScoreValue);
    }

    private void AddScore()
    {
        AddScoreValue(_additionValue);
    }

    private void AddScoreValue(int value)
    {
        _value += value;
        ScoreEvents.OnScoreChanged.Publish(_value);
    }

    private void SendScore()
    {
        ScoreEvents.OnScoreSaved.Publish(_value);
    }

    public int GetValue() => _value;
}
