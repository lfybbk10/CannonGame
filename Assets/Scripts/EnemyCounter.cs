using System;
using UnityEngine;


public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private int _maxCountEnemies;
    private int _countEnemies;
    
    private void OnEnable()
    {
        Events.OnEnemySpawned.Add(IncreaseCount);
    }

    private void OnDisable()
    {
        Events.OnEnemySpawned.Remove(IncreaseCount);
    }

    private void IncreaseCount()
    {
        _countEnemies++;
        if (_countEnemies >= _maxCountEnemies)
        {
            Events.OnLose.Publish();
        }
    }
}
