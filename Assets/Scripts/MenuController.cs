using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static string lastActiveScene;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(lastActiveScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}