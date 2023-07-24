using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        Destroy(MenuMusic.instance.gameObject);
        SceneManager.LoadScene("Game");
    } 

    public void Records() => SceneManager.LoadScene("Records");
    
    public void Titles() => SceneManager.LoadScene("Titles");
    
    public void Quit() => Application.Quit();
}
