using UnityEngine;

public class BusController : MonoBehaviour
{
    // define constants for the minimum and maximum speeds of the bus
    private const float MIN_SPEED = 0f;
    private const float MAX_SPEED = 60f;

    // define constants for the acceleration and deceleration rates of the bus
    private const float ACCELERATION_RATE = 2f;
    private const float DECELERATION_RATE = 4f;

    // define a variable for the current speed of the bus
    private float currentSpeed = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // accelerate the bus if it is below the maximum speed
            if (currentSpeed < MAX_SPEED)
            {
                currentSpeed += ACCELERATION_RATE;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // decelerate the bus if it is above the minimum speed
            if (currentSpeed > MIN_SPEED)
            {
                currentSpeed -= DECELERATION_RATE;
            }
        }
    }

    public void Stop()
    {
        // set the current speed of the bus to 0
        currentSpeed = 0f;
    }

    public void Turn(float direction)
    {
        // add code here to handle turning the bus in the specified direction
    }
}

