using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openDoor()
    {
        door.transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);
    }
}
