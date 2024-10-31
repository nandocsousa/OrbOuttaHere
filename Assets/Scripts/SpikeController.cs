using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeController : MonoBehaviour
{
    PlayerMovement player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("DeathMenu");
    }
}
