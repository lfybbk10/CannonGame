using System;
using System.Collections;
using UnityEngine;


public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float _destroyTime;

    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }
}
