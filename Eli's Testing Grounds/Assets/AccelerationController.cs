using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationController : MonoBehaviour
{
    public float accelerationFactor = 2f; // The factor by which to multiply the vehicle's move speed when accelerating
    public VehicleController vehicleController; // Reference to the VehicleController script

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Accelerate the vehicle by multiplying its move speed by the acceleration factor
            vehicleController.moveSpeed *= accelerationFactor;
        }
    }
}

