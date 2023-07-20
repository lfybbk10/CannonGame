using System;
using UnityEngine;


public class EnemyHP : MonoBehaviour
{
    private float _value;
    
    private void OnEnable()
    {
        Events.OnCannonBallHit.Add(GetDamage);
        Events.OnKillAllEnemies.Add(DestroyEnemy);
    }

    private void OnDisable()
    {
        Events.OnCannonBallHit.Remove(GetDamage);
        Events.OnKillAllEnemies.Remove(DestroyEnemy);
    }

    private void GetDamage(float value)
    {
        _value -= value;
        if (_value <= 0)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        Events.OnEnemyDestroyed.Publish();
    }
}
