using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // The player's transform to follow
    public Vector3 offset = new Vector3(0f, 2f, -10f); // Offset from the player's position
    public float smoothSpeed = 5f; // Smoothness of camera movement

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}