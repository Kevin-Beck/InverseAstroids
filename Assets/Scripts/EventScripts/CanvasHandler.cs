using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHandler : MonoBehaviour
{
    Canvas c;
    // Start is called before the first frame update
    void Awake()
    {
        c = GetComponent<Canvas>();
    }
    
    public void DisableCanvas()
    {
        c.enabled = false;
    }

    public void EnableCanvas()
    {
        c.enabled = true;
    }
}
