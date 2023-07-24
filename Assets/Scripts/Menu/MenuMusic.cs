using System;
using UnityEngine;


public class MenuMusic : MonoBehaviour
{
    public static MenuMusic instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }
}
