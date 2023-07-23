using System;
using System.Collections;
using UnityEngine;


public class RotateAnimation : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.03f);
            transform.Rotate(new Vector3(0,1,0),2);
        }
    }
}
