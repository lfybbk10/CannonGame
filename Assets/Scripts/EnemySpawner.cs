using System;
using System.Collections;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _spawnIntervalSec;

    private float _spawnTimer;

    private void OnEnable()
    {
        Events.OnPauseEnemySpawner.Add(PauseSpawner);
        StartCoroutine(SpawnCoroutine());
    }

    private void OnDisable()
    {
        Events.OnPauseEnemySpawner.Remove(PauseSpawner);
        _spawnTimer = 0;
        StopAllCoroutines();
    }

    private void PauseSpawner(int timeSec)
    {
        StartCoroutine(PauseCoroutine(timeSec));
    }

    private IEnumerator PauseCoroutine(int timeSec)
    {
        _spawnTimer = 0;
        StopAllCoroutines();
        yield return new WaitForSeconds(timeSec);
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            _spawnTimer += 0.05f;
            if (_spawnTimer >= _spawnIntervalSec)
            {
                _spawnTimer = 0;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        Events.OnEnemySpawned.Publish();
    }
}

