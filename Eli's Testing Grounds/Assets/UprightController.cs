using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UprightController : MonoBehaviour
{
    // Speed at which the vehicle returns to an upright position
    public float uprightSpeed = 90f;

    // Threshold for determining when the vehicle is upright
    public float uprightThreshold = 0.1f;

    void Update()
    {
        // Check if the F key is pressed
        if (Input.GetKey(KeyCode.F))
        {
            // Get the current rotation of the vehicle
            Quaternion currentRotation = transform.rotation;

            // Get the desired upright rotation of the vehicle
            Quaternion desiredRotation = Quaternion.Euler(0f, currentRotation.eulerAngles.y, 0f);

            // Check if the vehicle is already upright
            if (Quaternion.Angle(currentRotation, desiredRotation) > uprightThreshold)
            {
                // Rotate the vehicle towards the upright position
                transform.rotation = Quaternion.RotateTowards(currentRotation, desiredRotation, uprightSpeed * Time.deltaTime);
            }
        }
    }
}

