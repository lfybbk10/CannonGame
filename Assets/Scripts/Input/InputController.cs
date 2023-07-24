using System;
using UnityEngine;


public class InputController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            InputEvents.OnLeftMousePressed.Publish();
        }
    }
}
