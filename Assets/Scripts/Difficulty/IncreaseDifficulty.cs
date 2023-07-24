using System;
using UnityEngine;


public class IncreaseDifficulty : MonoBehaviour
{
    [SerializeField] private int _scoreStep;

    private int _nextDifficultyScore;

    private void Start()
    {
        _nextDifficultyScore = _scoreStep;
    }

    private void OnEnable()
    {
        ScoreEvents.OnScoreChanged.Add(GetChangedScore);
    }

    private void OnDisable()
    {
        ScoreEvents.OnScoreChanged.Remove(GetChangedScore);
    }

    private void GetChangedScore(int value)
    {
        if (value >= _nextDifficultyScore)
        {
            Increase();
        }
    }

    private void Increase()
    {
        _nextDifficultyScore += _scoreStep;
        GameProgressEvents.OnDifficultyIncreased.Publish();
        print("diff increase");
    }
}
