using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveForce = 10;

    public const float keyCoolDown = .2f;

    private float upKeyCoolDown;
    private float downKeyCoolDown;
    private float leftKeyCoolDown;
    private float rightKeyCoolDown;

    private int upCount = 0;
    private int downCount = 0;
    private int leftCount = 0;
    private int rightCount = 0;

    public float maxSpeed = 20;

    private void Start()
    {
        upKeyCoolDown = downKeyCoolDown = leftKeyCoolDown = rightKeyCoolDown = keyCoolDown;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * moveForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * moveForce);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * moveForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * moveForce);
        }
        CheckSpeed();
        
    }
    private void Update()
    {
        CheckForDash();
    }
    // This references the counters of the class for double tapping keys.
    private bool CheckForDash()
    {
        bool didWeDash = false;
        if (Input.anyKeyDown) // if we dont have a down key in this frame just quit
        {
            // check for up key press
            if (Input.GetKeyDown(KeyCode.W))
            {
                if(upKeyCoolDown > 0 && upCount == 1) // if we have already counted 1 and we are still on cooldown
                {
                    // We have double tapped up
                    if (rb.velocity.z < 0)
                    {
                        KeepVelocity(new Vector3(1, 1, 0)); // we want to reset the up direction to 0 velocity
                        didWeDash = true; // return true 
                    }
                }
                else // if we didnt catch a double key press, we add 1 to the counter, and we set the cooldown to the master cooldown value
                {
                    upKeyCoolDown = keyCoolDown;
                    upCount += 1;
                }
            }
            // The same process is repeated for down (s)
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (downKeyCoolDown > 0 && downCount == 1)
                {
                    // Double tapped up
                    if (rb.velocity.z > 0)
                    {
                        KeepVelocity(new Vector3(1, 1, 0));
                        didWeDash = true;
                    }
                }
                else
                {
                    downKeyCoolDown = keyCoolDown;
                    downCount += 1;
                }
            }
            // The same process is repeated for left (a)
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (leftKeyCoolDown > 0 && leftCount == 1)
                {
                    // Double tapped up
                    if (rb.velocity.x > 0)
                    {
                        KeepVelocity(new Vector3(0, 1, 1));
                        didWeDash = true;
                    }
                }
                else
                {
                    leftKeyCoolDown = keyCoolDown;
                    leftCount += 1;
                }
            }
            // The same process is repeated for right (d)
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (rightKeyCoolDown > 0 && rightCount == 1)
                {
                    // Double tapped up
                    if (rb.velocity.x < 0)
                    {
                        KeepVelocity(new Vector3(0, 1, 1));
                        didWeDash = true;
                    }
                }
                else
                {
                    rightKeyCoolDown = keyCoolDown;
                    rightCount += 1;
                }
            }

        }
        // Decay the timers on the directional counters
        if (upKeyCoolDown > 0)
        {
            upKeyCoolDown -= 1 * Time.deltaTime;
        }
        else
        {
            upCount = 0;
        }
        if (downKeyCoolDown > 0)
        {
            downKeyCoolDown -= 1 * Time.deltaTime;
        }
        else
        {
            downCount = 0;
        }
        if (leftKeyCoolDown > 0)
        {
            leftKeyCoolDown -= 1 * Time.deltaTime;
        }
        else
        {
            leftCount = 0;
        }
        if (rightKeyCoolDown > 0)
        {
            rightKeyCoolDown -= 1 * Time.deltaTime;
        }
        else
        {
            rightCount = 0;
        }

        return didWeDash;
    }

    private void CheckSpeed()
    {
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity *= .9f;
        }
    }

    // this function accepts a vector and keeps the scaled velocity in that direction;
    // ex: (1,1,1) keeps the exact velocity, (.5, .5, .5) would slow the velocity by half.
    // ex (0, 0, 1) keeps only the z velocity and halts the x and y direction
    private void KeepVelocity(Vector3 keepVector)
    {
        Vector3 velocityVector = rb.velocity;           
        rb.velocity = new Vector3(velocityVector.x*keepVector.x, velocityVector.y*keepVector.y, velocityVector.z*keepVector.z);
    }
}
