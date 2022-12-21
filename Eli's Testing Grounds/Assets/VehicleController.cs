using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float moveSpeed = 10f; // The speed at which the vehicle will move
    public float turnSpeed = 50f; // The speed at which the vehicle will turn

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get input from the A and D keys
        float verticalInput = Input.GetAxis("Vertical"); // Get input from the W and S keys

        // Use the input values to move and turn the vehicle
        transform.position += transform.forward * verticalInput * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime * Mathf.Sign(verticalInput));
    }
}

