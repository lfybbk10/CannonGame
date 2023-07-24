using System;
using UnityEngine;
using UnityEngine.Pool;


public class CannonBallFactory : MonoBehaviour
{
    [SerializeField] private CannonBallHit _cannonBallPrefab;
    [SerializeField] private Transform _spawnPoint;
    private ObjectPool<CannonBallHit> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<CannonBallHit>((() => Instantiate(_cannonBallPrefab, _spawnPoint.position, Quaternion.identity)),
            (obj =>
            {
                obj.gameObject.SetActive(true);
                obj.transform.position = _spawnPoint.position;
                obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }), (obj => obj.gameObject.SetActive(false)), Destroy);
    }

    private void OnEnable()
    {
        Events.OnCannonBallReleased.Add(Release);
    }

    private void OnDisable()
    {
        Events.OnCannonBallReleased.Remove(Release);
    }

    public CannonBallHit Get()
    {
        return _pool.Get();
    }

    private void Release(CannonBallHit cannonBall)
    {
        _pool.Release(cannonBall);
    }
}
