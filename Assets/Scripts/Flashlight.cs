using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    private bool enabled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            enabled = !enabled;
            flashlight.enabled = enabled;
        }
    }
}
