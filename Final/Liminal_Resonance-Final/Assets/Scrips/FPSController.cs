using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 2f;

    private CharacterController _cc;
    private Camera _cam;
    private float _pitch = 0f;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    private void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;
        _cc.SimpleMove(move * walkSpeed);
    }

    private void HandleMouseLook()
    {
        if (Cursor.lockState != CursorLockMode.Locked) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Horizontal rotation on the body
        transform.Rotate(Vector3.up * mouseX);

        // Vertical rotation clamped on the camera
        _pitch -= mouseY;
        _pitch = Mathf.Clamp(_pitch, -80f, 80f);
        _cam.transform.localEulerAngles = Vector3.right * _pitch;
    }
}
