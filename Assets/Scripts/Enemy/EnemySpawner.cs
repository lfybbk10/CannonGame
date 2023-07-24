using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _maxSpawnIntervalSec;

    private float _currInterval;

    private float _spawnTimer;

    private void Start()
    {
        ResetInterval();
        StartCoroutine(SpawnCoroutine());
    }

    private void OnEnable()
    {
        BoosterEvents.OnPauseEnemySpawner.Add(PauseSpawner);
    }

    private void OnDisable()
    {
        BoosterEvents.OnPauseEnemySpawner.Remove(PauseSpawner);
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
        StopCoroutine(SpawnCoroutine());
        yield return new WaitForSeconds(timeSec);
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= _currInterval)
            {
                _spawnTimer = 0;
                SpawnEnemy();
                ResetInterval();
            }
        }
    }

    private void SpawnEnemy() => EnemyEvents.OnEnemySpawned.Publish();

    private void ResetInterval() => _currInterval = Random.Range(1, _maxSpawnIntervalSec);
}

