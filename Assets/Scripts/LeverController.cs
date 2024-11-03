using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public GameObject leverDeactivated;
    public GameObject leverActivated;

    private bool isActive = false;
    private bool playerInRange = false;

    [SerializeField] private GameObject door;
    private DoorController doorController;

    private void Start()
    {
        doorController = door.GetComponent<DoorController>();

        DeactivateLever();
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            PullLever();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void PullLever()
    {
        if (!isActive)
        {
            ActivateLever();
            doorController.OpenDoor();
        }
        else if (isActive)
        {
            DeactivateLever();
            doorController.CloseDoor();
        }
    }

    private void ActivateLever()
    {
        leverDeactivated.SetActive(false);
        leverActivated.SetActive(true);
        isActive = true;
    }

    private void DeactivateLever()
    {
        leverDeactivated.SetActive(true);
        leverActivated.SetActive(false);
        isActive = false;
    }
}
