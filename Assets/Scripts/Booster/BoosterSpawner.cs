using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BoosterSpawner : MonoBehaviour
{
    [SerializeField] private List<Booster> _boosterPrefabs;

    private readonly int _minNecessaryCountEnemies = 7;
    private readonly int _maxNecessaryCountEnemies = 14;

    private int _currNecessaryCountEnemies;

    private void Start()
    {
        CalcCountEnemies();
    }

    private void OnEnable()
    {
        Events.OnEnemyDestroyed.Add(ReduceEnemyCount);
    }

    private void OnDisable()
    {
        Events.OnEnemyDestroyed.Remove(ReduceEnemyCount);
    }

    private void ReduceEnemyCount()
    {
        _currNecessaryCountEnemies--;
        if (_currNecessaryCountEnemies == 0)
            SpawnBooster();
    }

    private void SpawnBooster()
    {
        var boosterPrefab = _boosterPrefabs.GetRandomElem();
        var booster = Instantiate(boosterPrefab, RandomFieldPoint.instance.Get(), Quaternion.identity);
        booster.transform.position = new Vector3(booster.transform.position.x, 3, booster.transform.position.z);
        CalcCountEnemies();
    }

    private void CalcCountEnemies() => _currNecessaryCountEnemies = Random.Range(_minNecessaryCountEnemies, _maxNecessaryCountEnemies);
}
