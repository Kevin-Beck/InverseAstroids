using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventOnAwake : MonoBehaviour
{
    public GameEvent Event;
    private void Start()
    {
        Event.Raise();
    }

}
