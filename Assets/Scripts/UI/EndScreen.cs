using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        Events.OnLose.Add(Activate);
    }

    private void OnDisable()
    {
        Events.OnLose.Remove(Activate);
    }

    private void Activate()
    {
        _scoreText.text = "Очки: " + _score.GetValue();
        _window.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
