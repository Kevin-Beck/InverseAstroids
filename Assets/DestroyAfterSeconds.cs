using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", time);
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
