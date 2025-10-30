using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // The object the camera will follow 
    public float smooth = 6f;          // How quickly the camera moves toward the target
    public Vector2 offset = new Vector2(3f, 1.5f); // Offset from the target’s position

    void LateUpdate()
    {
        // Don’t run if there’s no target assigned
        if (!target) return;

        // Calculate the desired camera position based on target and offset
        Vector3 desired = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            transform.position.z);

        // Smoothly move the camera toward the desired position
        transform.position = Vector3.Lerp(transform.position, desired, smooth * Time.deltaTime);
    }
}