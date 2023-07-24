using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CannonBallHit))]
public class CannonBallReleaseTimer : MonoBehaviour
{
    [SerializeField] private float _releaseTime;

    private CannonBallHit _cannonBall;

    private void Awake()
    {
        _cannonBall = GetComponent<CannonBallHit>();
    }

    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(_releaseTime);
        Events.OnCannonBallReleased.Publish(_cannonBall);
    }
}
