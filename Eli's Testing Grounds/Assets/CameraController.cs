using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // assign this in the Inspector
    public float distance = 10.0f;
    public float height = 5.0f;

    void Update()
    {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = player.position + Vector3.up * height - player.forward * distance;

        // Set the position of the camera
        transform.position = desiredPosition;

        // Orient the camera towards the player, but keep the x and z rotation fixed
        transform.LookAt(player, Vector3.up);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);
    }
}

