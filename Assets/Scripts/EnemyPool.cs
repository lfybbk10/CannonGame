using System;
using UnityEngine;
using UnityEngine.Pool;


public class EnemyPool : MonoBehaviour
{
    private GameObject _enemyPrefab;
    private ObjectPool<GameObject> _enemyPool;

    private void Start()
    {
        _enemyPool = new ObjectPool<GameObject>((() => Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity)),
            (obj =>
            {
                obj.transform.position = RandomFieldPoint.instance.Get();
                obj.SetActive(true);
            }), (obj => obj.SetActive(false)), (obj) => Destroy(obj), false, 15, 15);
    }

    private void OnEnable()
    {
        Events.OnEnemySpawned.Add(GetEnemy);
        Events.OnEnemyReleased.Add(ReleaseEnemy);
    }

    private void OnDisable()
    {
        Events.OnEnemySpawned.Remove(GetEnemy);
        Events.OnEnemyReleased.Remove(ReleaseEnemy);
    }

    private void GetEnemy()
    {
        _enemyPool.Get();
    }

    private void ReleaseEnemy(GameObject enemy)
    {
        _enemyPool.Release(enemy);
    }
}
