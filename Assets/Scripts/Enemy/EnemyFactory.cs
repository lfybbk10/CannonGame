using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private float _startHP;
    
    private ObjectPool<GameObject> _enemyPool;
    
    private float _hpStep = 1.5f;
    private float _currHp;


    private void Awake()
    {
        _currHp = _startHP;
        _enemyPool = new ObjectPool<GameObject>((() => Instantiate(_enemyPrefabs.GetRandomElem(), new Vector3(0,1,0), Quaternion.identity)),
            (obj =>
            {
                obj.transform.position = RandomFieldPoint.instance.Get();
                obj.GetComponent<EnemyHP>().SetValue(_currHp);
                obj.SetActive(true);
            }), (obj => obj.SetActive(false)), Destroy);
    }

    private void OnEnable()
    {
        Events.OnEnemySpawned.Add(GetEnemy);
        Events.OnEnemyReleased.Add(ReleaseEnemy);
        Events.OnDifficultyIncreased.Add(IncreaseHP);
    }

    private void OnDisable()
    {
        Events.OnEnemySpawned.Remove(GetEnemy);
        Events.OnEnemyReleased.Remove(ReleaseEnemy);
        Events.OnDifficultyIncreased.Remove(IncreaseHP);
    }

    private void GetEnemy()
    {
        _enemyPool.Get();
    }

    private void ReleaseEnemy(GameObject enemy)
    {
        _enemyPool.Release(enemy);
    }

    private void IncreaseHP()
    {
        _currHp *= _hpStep;
    }
}
