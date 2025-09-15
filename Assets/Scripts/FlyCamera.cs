using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float sensitivity = 5f;
    public float normalSpeed = 10f;
    public float sprintSpeed = 20f;
    public float slowSpeed = 5f;

    private float currentSpeed;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        currentSpeed = normalSpeed;
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor on start
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse Look
        if (Input.GetMouseButton(1)) // Right mouse button held down
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            rotationY += Input.GetAxis("Mouse X") * sensitivity;
            rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp vertical rotation

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Movement Speed Control
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed = slowSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }

        // Keyboard Movement
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) moveDirection += transform.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection -= transform.forward;
        if (Input.GetKey(KeyCode.A)) moveDirection -= transform.right;
        if (Input.GetKey(KeyCode.D)) moveDirection += transform.right;
        if (Input.GetKey(KeyCode.E)) moveDirection += transform.up;
        if (Input.GetKey(KeyCode.Q)) moveDirection -= transform.up;

        transform.Translate(moveDirection.normalized * currentSpeed * Time.deltaTime, Space.World);
    }
}