using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth = 6f;
    public Vector2 offset = new Vector2(3f, 1.5f);

    void LateUpdate()
    {
        if (!target) return;
        Vector3 desired = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desired, smooth * Time.deltaTime);
    }
}
