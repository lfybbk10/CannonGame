using System;
using UnityEngine;


public class EnemyHP : MonoBehaviour, IHittable, IHP
{
    public Action<float> OnValueChanged { get; set; }
    
    public Action OnGetHit { get; set; }
    
    private float _maxValue;
    private float _value;

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
        _value -= value;
        OnValueChanged?.Invoke(_value);
        OnGetHit?.Invoke();
        if (_value <= 0)
        {
            DestroyEnemy();
        }
        else
        {
            Events.OnEnemyDamaged.Publish();
        }
    }

    private void DestroyEnemy()
    {
        Events.OnEnemyDestroyed.Publish();
        Events.OnEnemyReleased.Publish(gameObject);
    }
    

    public float GetMaxValue()
    {
        return _maxValue;
    }

    public float GetValue()
    {
        return _value;
    }

    public void SetValue(float value)
    {
        _maxValue = value;
        _value = value;
        OnValueChanged?.Invoke(_value);
    }
}
