using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow (e.g. the vehicle)
    public float smoothTime = 0.1f; // The time it takes for the camera to catch up to the target
    public Vector3 offset; // The offset from the target to position the camera at
    public float rotationSmoothTime = 0.1f; // The time it takes for the camera to rotate to face the target
    public float rotationSpeed = 5f; // The speed at which the camera will rotate to face the target

    private Vector3 velocity = Vector3.zero; // The velocity of the camera's movement
    private Vector3 rotationVelocity = Vector3.zero; // The angular velocity of the camera's rotation

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        // Keep the camera locked at a fixed distance from the target
        transform.position = target.position + offset;

        // Smoothly rotate the camera to face the target
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}





