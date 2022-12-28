using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    // Maximum turning rate of the vehicle, in degrees per second
    public float maxTurnRate = 90f;

    // Current velocity of the vehicle
    public Vector3 velocity;

    // Speed of the vehicle
    public float speed = 10f;

    // Acceleration of the vehicle when moving forward or backward
    public float acceleration = 10f;

    // Deceleration of the vehicle when not moving forward or backward
    public float deceleration = 10f;

    // Drag applied to the vehicle when not moving forward or backward
    public float drag = 0.1f;

    void Update()
    {
        // Get input from WSAD keys
        float forward = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        // Update velocity based on input
        velocity += transform.forward * acceleration * forward * Time.deltaTime;

        // Clamp the velocity to the desired speed
        velocity = Vector3.ClampMagnitude(velocity, speed);

        // Apply deceleration and drag to velocity
        velocity -= velocity * deceleration * Time.deltaTime;
        velocity -= velocity * drag * Time.deltaTime;

        // Rotate the vehicle based on turn input, smoothing the turn rate over time
        transform.Rotate(Vector3.up, Mathf.Lerp(0f, turn * maxTurnRate, Time.deltaTime));

        // Move the vehicle based on velocity
        transform.position += velocity * Time.deltaTime;
    }
}
































