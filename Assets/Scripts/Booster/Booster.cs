using UnityEngine;


public abstract class Booster : MonoBehaviour, IHittable
{
    public abstract void Activate();
    public void GetHit(float hitValue)
    {
        Events.OnBoosterTaken.Publish();
        Activate();
        Destroy(gameObject);
    }
}
