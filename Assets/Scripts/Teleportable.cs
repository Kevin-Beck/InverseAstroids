using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    public bool isTeleportable;

    public void DisableTeleport()
    {
        isTeleportable = false;
    }
    public void EnableTeleport()
    {
        isTeleportable = true;
    }
    private void Awake()
    {
        isTeleportable = true;
    }
}
