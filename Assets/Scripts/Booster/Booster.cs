using System;
using UnityEngine;


public abstract class Booster : MonoBehaviour, IHittable
{
    public Action OnGetHit { get; set; }
    public abstract void Activate();

    public void GetHit(float hitValue)
    {
        OnGetHit?.Invoke();
        Events.OnBoosterTaken.Publish();
        Activate();
        Destroy(gameObject);
    }
}
