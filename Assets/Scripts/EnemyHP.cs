using System;
using UnityEngine;


public class EnemyHP : MonoBehaviour
{
    private float _value;
    
    private void OnEnable()
    {
        Events.OnCannonBallHit.Add(GetDamage);
    }

    private void OnDisable()
    {
        Events.OnCannonBallHit.Remove(GetDamage);
    }

    private void GetDamage(float value)
    {
        _value -= value;
        if (_value <= 0)
        {
            Destroy(gameObject);
            Events.OnEnemyDestroyed.Publish();
        }
    }
}
