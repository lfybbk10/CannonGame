using System;
using System.Collections;
using UnityEngine;


public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject _cannonBallPrefab;
    [SerializeField] private float _shootInterval;

    private bool isReloading;

    private float _upgradeStep = 0.5f;

    private void OnEnable()
    {
        Events.OnLeftMouseDown.Add(Shoot);
    }

    private void OnDisable()
    {
        Events.OnLeftMouseDown.Remove(Shoot);
    }

    private void Shoot()
    {
        //спаун в нужной точке и придача силы в нужном направлении
        
        StartCoroutine(Reload());
        throw new NotImplementedException();
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(_shootInterval);
        isReloading = false;
    }

    private void UpgradeShootSpeed()
    {
        _shootInterval *= _upgradeStep;
    }
}
