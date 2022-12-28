using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClipController : MonoBehaviour
{
    // Speed at which the vehicle returns to an upright position
    public float correctionSpeed = 10f;

    // Threshold for determining when the vehicle is upright
    public float correctionThreshold = 0.1f;

    // Layermask for objects the vehicle should not pass through
    public LayerMask noClipLayers;

    void Update()
    {
        // Raycast from the center of the vehicle to check for collisions
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f, noClipLayers))
        {
            // If a collision is detected, move the vehicle back slightly
            transform.position -= transform.forward * correctionSpeed * Time.deltaTime;
        }
    }
}

