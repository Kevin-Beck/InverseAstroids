using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 teleportOffset;


    private void OnTriggerEnter(Collider other)
    {
        Teleportable t = other.GetComponent<Teleportable>();
        if(t != null && t.isTeleportable)
        {
            // Get the position of the object that is hitting the barrier
            Vector3 OriginalPosition = other.transform.position;
            // mirror the position
            Vector3 TargetPosition = InvertPosition(OriginalPosition);
            other.gameObject.transform.position = TargetPosition + teleportOffset;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    private Vector3 InvertPosition(Vector3 pos)
    {
        return new Vector3(pos.x * -1, pos.y, pos.z * -1);
    }
}
