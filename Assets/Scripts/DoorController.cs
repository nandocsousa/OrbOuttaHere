using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject topClosed;
    public GameObject botClosed;

    public GameObject topOpened;
    public GameObject botOpened;

    private void Start()
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        topClosed.SetActive(false);
        botClosed.SetActive(false);

        topOpened.SetActive(true);
        botOpened.SetActive(true);
    }

    public void CloseDoor()
    {
        topClosed.SetActive(true);
        botClosed.SetActive(true);

        topOpened.SetActive(false);
        botOpened.SetActive(false);
    }
}
