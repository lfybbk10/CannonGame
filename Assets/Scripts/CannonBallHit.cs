using System;
using UnityEngine;


public class CannonBallHit : MonoBehaviour
{
    [SerializeField] private float _hitValue;
    [SerializeField] private LayerMask _hitMask;
    private void OnTriggerEnter(Collider other)
    {
        if (_hitMask.Contains(other.gameObject.layer))
        {
            Events.OnCannonBallHit.Publish(_hitValue);
        }
    }
}
