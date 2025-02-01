using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    public Rigidbody2D rb;
    public float rbVelocity = 2f;

    void Update()
    {
        rb.velocity = Vector3.up * rbVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Speed"))
        {
            rbVelocity += 2f;
            Debug.Log(rbVelocity);

        }

        if (other.CompareTag("Barrier"))
        {
            rbVelocity = 0f;
            Debug.Log(rbVelocity);
        }
    }
}