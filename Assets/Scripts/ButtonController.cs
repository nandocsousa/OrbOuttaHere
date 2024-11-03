using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject door;
    private DoorController doorController;

    private void Start()
    {
        doorController = door.GetComponent<DoorController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            doorController.OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            doorController.CloseDoor();
        }
    }
}
