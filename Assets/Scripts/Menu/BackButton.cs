using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BackButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Back);
    }

    public void Back() => SceneManager.LoadScene("Menu");
}
