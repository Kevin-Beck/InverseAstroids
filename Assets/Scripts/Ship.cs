using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameEvent myDeath;
    public ShipAI brain;
    Rigidbody rb;
    public GameObject projectile;
    public float projectileDistance = 2;
    public float speed = 150;
    public float turn = 15;
    public bool shootWhenTargetted = true;
    public float shootCooldown = 1;
    bool descend = true;

    // Descending
    public float descendSpeed = 10f;
    private float startTime;
    private float journeyLength;
    public GameObject shield;
    private Vector3 startPos;
    private Vector3 targetPos;

    private void FixedUpdate()
    {
        if (shootWhenTargetted)
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position + transform.forward * projectileDistance, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "Player")
                    Shoot();
            }
        }
    }
    private void Update()
    {
        if (descend)
        {            
            Descend();
            if (transform.position.y < 1.7)
            {
                descend = false;
                shield.SetActive(false);
                MoveForwards();
                MoveForwards();
            }
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, new Vector3(transform.position.x, 1.6f, transform.position.z));
        startPos = transform.position;
        targetPos = new Vector3(Random.Range(-30f, 30f), 1.6f, Random.Range(-20f, 20f));
        Invoke("NextChoice", 3);
        
    }
    private void NextChoice()
    {
        Actions a = brain.MakeNextAction();
        if (a == Actions.MoveForward)
            MoveForwards();
        else if (a == Actions.MoveBackward)
            MoveBackwards();
        else if (a == Actions.TurnLeft)
            TurnLeft();
        else if (a == Actions.TurnRight)
            TurnRight();
        else if (a == Actions.Shoot)
            Shoot();
        Invoke("NextChoice", Random.Range(1, 3));
    }
    public void Descend()
    {
        float distCovered = (Time.time - startTime) * descendSpeed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPos, targetPos, fracJourney);
        rb.AddRelativeTorque(Vector3.down * Random.Range(-10f, 10f));
    }
    public void MoveForwards()
    {
        rb.AddForce(transform.forward * speed);
    }
    public void MoveBackwards()
    {
        rb.AddForce(transform.forward * -1f * speed);
    }
    public void TurnLeft()
    {
        rb.AddTorque(Vector3.down * turn);
    }
    public void TurnRight()
    {
        rb.AddTorque(Vector3.up * turn);
    }

    public void Shoot()
    {
        if (shootWhenTargetted)
        {
            GameObject go = Instantiate(projectile, transform.position + transform.forward * projectileDistance, transform.rotation);
            go.transform.parent = gameObject.transform;
            shootWhenTargetted = false;
            Invoke("ResetShootCooldown", shootCooldown);
        }
    }

    public void ResetShootCooldown()
    {
        shootWhenTargetted = true;
    }
    private void OnDestroy()
    {
        CancelInvoke("Fire");
        myDeath.Raise();
    }
    
}
