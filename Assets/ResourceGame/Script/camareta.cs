using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lookSpeed = 2f;
    public float fastMoveMultiplier = 3f;

    private float yaw;
    private float pitch;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center
    }

    void Update()
    {
        // Mouse look
        yaw += Input.GetAxis("Mouse X") * lookSpeed;
        pitch -= Input.GetAxis("Mouse Y") * lookSpeed;
        pitch = Mathf.Clamp(pitch, -89f, 89f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        // Keyboard move
        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
            speed *= fastMoveMultiplier;

        Vector3 move = new Vector3(
            Input.GetAxis("Horizontal"),
            (Input.GetKey(KeyCode.E) ? 1 : 0) - (Input.GetKey(KeyCode.Q) ? 1 : 0),
            Input.GetAxis("Vertical")
        );

        transform.Translate(move * speed * Time.deltaTime, Space.Self);

        // Unlock cursor with Escape
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }
}
