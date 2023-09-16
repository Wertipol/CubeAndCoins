using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour
{
    public string nameScene;
    public void PlayGame()
    {
        if (nameScene == "menu")
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
