using System;
using UnityEngine;


public class Input : MonoBehaviour
{
    private void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            Events.OnLeftMouseDown.Publish();
        }
    }
}
