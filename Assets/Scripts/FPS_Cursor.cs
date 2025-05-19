using UnityEngine;
using UnityEngine.InputSystem;

public class FPS_Cursor : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Camera playerCamera;

    private PlayerInputActions inputActions;
    private Vector2 mouseDelta;
    private float xRotation = 0f;

    private bool isPaused => Time.timeScale == 0;

    void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.Player.Look.performed += ctx => mouseDelta = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => mouseDelta = Vector2.zero;
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
    }

    void OnDisable()
    {
        if (inputActions != null)
            inputActions.Player.Disable();
    }

    void Start()
    {
        LockCursor();
    }

    void Update()
    {
        // Update cursor lock state based on pause
        if (isPaused)
        {
            UnlockCursor();
            return; // Don't process look movement while paused
        }
        else
        {
            LockCursor();
        }

        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
