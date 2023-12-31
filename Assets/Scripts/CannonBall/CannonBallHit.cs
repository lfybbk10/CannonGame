﻿using System;
using UnityEngine;


public class CannonBallHit : MonoBehaviour
{
    [HideInInspector] public float HitValue;
    [SerializeField] private LayerMask _hitMask;

    private void OnTriggerEnter(Collider other)
    {
        if (_hitMask.Contains(other.gameObject.layer))
        {
            if (other.TryGetComponent(out IHittable hittable))
            {
                hittable.GetHit(HitValue);
                CannonBallEvents.OnCannonBallReleased.Publish(this);
            }
        }
    }
}
