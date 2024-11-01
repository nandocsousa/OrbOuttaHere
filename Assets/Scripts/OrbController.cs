using UnityEngine;

public class OrbController : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform") || collision.collider.CompareTag("Spike"))
        {
            player.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
