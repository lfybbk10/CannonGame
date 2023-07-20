using System;
using UnityEngine;


public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject _cannonBallPrefab;

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
        throw new NotImplementedException();
    }
}
