using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _damage, _death;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EnemyEvents.OnEnemyDamaged.Add(PlayDamageSound);
        EnemyEvents.OnEnemyDestroyed.Add(PlayDeathSound);
        BoosterEvents.OnBoosterTaken.Add(PlayDeathSound);
    }

    private void OnDisable()
    {
        EnemyEvents.OnEnemyDamaged.Remove(PlayDamageSound);
        EnemyEvents.OnEnemyDestroyed.Remove(PlayDeathSound);
        BoosterEvents.OnBoosterTaken.Remove(PlayDeathSound);
    }

    private void PlayDamageSound() => _audioSource.PlayOneShot(_damage);
    
    private void PlayDeathSound() => _audioSource.PlayOneShot(_death);
}
