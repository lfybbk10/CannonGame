using System;
using System.Collections;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _spawnIntervalSec;

    private float _spawnTimer;
    

    private void OnEnable()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void OnDisable()
    {
        _spawnTimer = 0;
        StopAllCoroutines();
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
        throw new NotImplementedException();
    }
}

