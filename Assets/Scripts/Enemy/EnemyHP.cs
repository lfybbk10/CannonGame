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
        BoosterEvents.OnKillAllEnemies.Add(DestroyEnemy);
    }

    private void OnDisable()
    {
        BoosterEvents.OnKillAllEnemies.Remove(DestroyEnemy);
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
            EnemyEvents.OnEnemyDamaged.Publish();
        }
    }

    private void DestroyEnemy()
    {
        EnemyEvents.OnEnemyDestroyed.Publish();
        EnemyEvents.OnEnemyReleased.Publish(gameObject);
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
