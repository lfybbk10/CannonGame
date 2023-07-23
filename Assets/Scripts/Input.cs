using System;
using UnityEngine;


public class Input : MonoBehaviour
{
    private void Update()
    {
        if (UnityEngine.Input.GetMouseButton(0))
        {
            Events.OnLeftMousePressed.Publish();
        }
    }
}
