using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MenuController.lastActiveScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("DeathMenu");
    }
}
