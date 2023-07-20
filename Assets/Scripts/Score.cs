using System;
using UnityEngine;


public class Score : MonoBehaviour
{
    private int _value;
    private int _additionValue;
    
    private void OnEnable()
    {
        Events.OnEnemyDestroyed.Add(AddScore);
    }

    private void OnDisable()
    {
        Events.OnEnemyDestroyed.Remove(AddScore);
    }

    private void AddScore()
    {
        _value += _additionValue;
        Events.OnScoreChanged.Publish(_value);
    }
}
