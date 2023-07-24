using System;
using System.Collections;
using UnityEngine;


public class CannonShoot : MonoBehaviour
{
    [SerializeField] private CannonBallFactory _cannonBallFactory;
    [SerializeField] private float _shootInterval;
    [SerializeField] private float _damageValue;

    private bool _isReloading;

    private readonly float _upgradeSpeedStep = 0.7f;
    private readonly float _upgradeDamageStep = 1.5f;

    private void OnEnable()
    {
        InputEvents.OnLeftMousePressed.Add(Shoot);
        BoosterEvents.OnUpgradeCannonSpeed.Add(UpgradeShootSpeed);
        BoosterEvents.OnUpgradeCannonDamage.Add(UpgradeShootDamage);
    }

    private void OnDisable()
    {
        InputEvents.OnLeftMousePressed.Remove(Shoot);
        BoosterEvents.OnUpgradeCannonSpeed.Remove(UpgradeShootSpeed);
        BoosterEvents.OnUpgradeCannonDamage.Remove(UpgradeShootDamage);
    }

    private void Shoot()
    {
        if(_isReloading)
            return;

        Vector3 mousePos = UnityEngine.Input.mousePosition;
        var aim = Camera.main.ScreenToViewportPoint(mousePos);
        aim.x -= 0.5f;
        aim.y -= 0.5f;

        var cannonBall = _cannonBallFactory.Get();
        cannonBall.HitValue = _damageValue;
        cannonBall.GetComponent<Rigidbody>().AddForce(new Vector3(-1,aim.y,aim.x*2)*2000f);

        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_shootInterval);
        _isReloading = false;
    }

    private void UpgradeShootSpeed()
    {
        _shootInterval *= _upgradeSpeedStep;
    }

    private void UpgradeShootDamage()
    {
        _damageValue *= _upgradeDamageStep;
    }
}
