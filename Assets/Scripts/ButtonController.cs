using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject door;
    private DoorController doorController;

    private AudioManager audioManager;

    public GameObject deactivatedButton;
    public GameObject activatedButton;

    private void Start()
    {
        doorController = door.GetComponent<DoorController>();
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();

        deactivatedButton.SetActive(true);
        activatedButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            doorController.OpenDoor();
            audioManager.PlaySFX(audioManager.door);

            deactivatedButton.SetActive(false);
            activatedButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            doorController.CloseDoor();
            audioManager.PlaySFX(audioManager.door);

            deactivatedButton.SetActive(true);
            activatedButton.SetActive(false);
        }
    }
}
