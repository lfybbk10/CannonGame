using System;
using UnityEngine;

[RequireComponent(typeof(IHittable))]
public class HitParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particlePrefab;

    private IHittable _hittable;

    private void Awake()
    {
        _hittable = GetComponent<IHittable>();
    }

    private void OnEnable()
    {
        _hittable.OnGetHit += PlayParticle;
    }

    private void OnDisable()
    {
        _hittable.OnGetHit -= PlayParticle;
    }

    private void PlayParticle()
    {
        var particle = Instantiate(_particlePrefab, transform.position, Quaternion.identity);
        particle.Stop();
        particle.Play();
    }
}
