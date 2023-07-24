using System;
using UnityEngine;


public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private int _maxCountEnemies;
    private int _countEnemies;
    
    private void OnEnable()
    {
        EnemyEvents.OnEnemySpawned.Add(IncreaseCount);
        EnemyEvents.OnEnemyDestroyed.Add(DecreaseCount);
    }

    private void OnDisable()
    {
        EnemyEvents.OnEnemySpawned.Remove(IncreaseCount);
        EnemyEvents.OnEnemyDestroyed.Add(DecreaseCount);
    }

    private void IncreaseCount()
    {
        _countEnemies++;
        EnemyEvents.OnChangeEnemiesCount.Publish(_countEnemies);
        if (_countEnemies >= _maxCountEnemies)
        {
            GameProgressEvents.OnLose.Publish();
        }
    }

    private void DecreaseCount()
    {
        _countEnemies--;
        EnemyEvents.OnChangeEnemiesCount.Publish(_countEnemies);
    }
}
