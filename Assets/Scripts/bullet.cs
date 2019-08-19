using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float aliveTime;
    public GameObject secondaryProjectile;
    public bool hasSecondaryProjectile;

    public GameEvent PlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        Invoke("SelfDestruct", aliveTime);
    }

    private void SelfDestruct()
    {
        if (hasSecondaryProjectile)
        {
            Instantiate(secondaryProjectile, transform.position + transform.forward, transform.rotation);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerDeath.Raise();
        }
    }
}
