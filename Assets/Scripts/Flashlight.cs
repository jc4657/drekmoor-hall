using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    private bool enabled;

    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enabled = true;
        timer = 2000.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            enabled = !enabled;
            flashlight.enabled = enabled;
        }

        if (enabled)
        {
            countDown();
        }
        else
        {
            countUp();
        }
    }

    void countDown()
    {
        timer--;
        if (timer <= 0.0f)
        {
            if (enabled == true)
            {
                enabled = !enabled;
                flashlight.enabled = enabled;
            }
            timer = 0.0f;
        }
    }

    void countUp() {
        timer++;
        if (timer >= 500.0f)
        {
            timer = 2000.0f;
        }
    }
}
