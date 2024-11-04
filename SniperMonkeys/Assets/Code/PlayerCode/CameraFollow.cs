using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player transform
    public Vector3 offset;   // Offset from the player position
    public float smoothSpeed = 0.125f; // Smoothing speed factor

    void LateUpdate()
    {
        // Check if player is assigned
        if (player != null)
        {
            // Desired position based on the player's position and the offset
            Vector3 desiredPosition = player.position + offset;

            // Smoothly interpolate between the camera's current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}

