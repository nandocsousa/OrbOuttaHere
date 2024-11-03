using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            MenuController.lastActiveScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("DeathMenu");
        }
    }
}
