using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGameEvent : MonoBehaviour
{
    public GameEvent gameEvent;

    public void RaiseEvent()
    {
        gameEvent.Raise();
    }
}
