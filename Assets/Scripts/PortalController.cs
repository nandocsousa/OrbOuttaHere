using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public string nextLevel;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);

            if (nextLevel == "CompleteMenu")
            {
                audioManager.PlaySFX(audioManager.complete);
            }
        }
    }
}
