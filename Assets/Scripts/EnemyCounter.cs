using System;
using UnityEngine;


public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private int _maxCountEnemies;
    private int _countEnemies;
    
    private void OnEnable()
    {
        Events.OnEnemySpawned.Add(IncreaseCount);
        Events.OnEnemyDestroyed.Add(DecreaseCount);
    }

    private void OnDisable()
    {
        Events.OnEnemySpawned.Remove(IncreaseCount);
        Events.OnEnemyDestroyed.Add(DecreaseCount);
    }

    private void IncreaseCount()
    {
        _countEnemies++;
        Events.OnChangeEnemiesCount.Publish(_countEnemies);
        if (_countEnemies >= _maxCountEnemies)
        {
            Events.OnLose.Publish();
        }
    }

    private void DecreaseCount()
    {
        _countEnemies--;
        Events.OnChangeEnemiesCount.Publish(_countEnemies);
    }
}
