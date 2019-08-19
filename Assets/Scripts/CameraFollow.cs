using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 0.125f; // higher is faster to lock to player
    public Vector3 offset;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed); // 0 is first position, 1 is desired, .5 is halfway
        // if you use 1 it will automatically put the camera in the desiredPosition instantly in each frame
        // if you use .5 it will scoot halfway there every frame
        transform.position = target.position + offset;
    }
}
