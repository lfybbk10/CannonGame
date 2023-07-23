using System;
using UnityEngine;


public class EnemyHP : MonoBehaviour, IHittable
{
    public float Value;

    private void OnEnable()
    {
        Events.OnKillAllEnemies.Add(DestroyEnemy);
    }

    private void OnDisable()
    {
        Events.OnKillAllEnemies.Remove(DestroyEnemy);
    }

    public void GetHit(float value)
    {
        Value -= value;
        if (Value <= 0)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        Events.OnEnemyDestroyed.Publish();
        Events.OnEnemyReleased.Publish(gameObject);
    }
}
