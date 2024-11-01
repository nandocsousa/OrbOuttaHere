using UnityEngine;

public class OrbController : MonoBehaviour
{
    private GameObject player;
    private ThrowOrb throwOrb;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        throwOrb = player.GetComponent<ThrowOrb>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") || collision.CompareTag("Spike"))
        {
            player.transform.position = transform.position;
            throwOrb.isAlive = false;
            Destroy(gameObject);
        }
    }
}
