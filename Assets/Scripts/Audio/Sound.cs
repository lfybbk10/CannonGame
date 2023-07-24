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
        Events.OnEnemyDamaged.Add(PlayDamageSound);
        Events.OnEnemyDestroyed.Add(PlayDeathSound);
        Events.OnBoosterTaken.Add(PlayDeathSound);
    }

    private void OnDisable()
    {
        Events.OnEnemyDamaged.Remove(PlayDamageSound);
        Events.OnEnemyDestroyed.Remove(PlayDeathSound);
        Events.OnBoosterTaken.Remove(PlayDeathSound);
    }

    private void PlayDamageSound() => _audioSource.PlayOneShot(_damage);
    
    private void PlayDeathSound() => _audioSource.PlayOneShot(_death);
}
