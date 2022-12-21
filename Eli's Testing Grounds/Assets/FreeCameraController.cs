using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    // Speed at which the camera moves
    public float speed = 5f;

    void Update()
    {
        // Get input for moving the camera
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the camera's movement vector
        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the camera
        transform.position += movement;

        // Get input for rotating the camera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera
        transform.Rotate(-mouseY, mouseX, 0);
    }
}

