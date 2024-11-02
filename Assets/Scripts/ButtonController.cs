using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private GameObject door;
    private DoorController doorController;

    private void Start()
    {
        door = GameObject.FindWithTag("Door");
        doorController = door.GetComponent<DoorController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorController.OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorController.CloseDoor();
        }
    }
}
