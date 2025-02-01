using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float rbVelocity = 2f;
    [SerializeField] private float speed = 20;
    private Vector3 startingPosition;
    private Vector3 targetPosition;
    [SerializeField] private Vector3 displacement = new Vector3(3, 0, 0);
 
    void Update()
    {
        rb.velocity = Vector3.up * rbVelocity;

        if (Input.GetKeyDown(KeyCode.A)) {
            startingPosition = rb.position;
            targetPosition = startingPosition - displacement;             
        } else if (Input.GetKeyDown(KeyCode.D)) {
            startingPosition = rb.position;
            targetPosition = startingPosition + displacement;
        }

        float rbX = Mathf.Lerp(rb.position.x, targetPosition.x, speed * Time.deltaTime);
        rb.position = new Vector2(rbX, rb.position.y); // rb.MovePosition(new Vector2(movePosition.x, rb.position.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Speed"))
        {
            rbVelocity += 2f;
            Debug.Log(rbVelocity);
        }

        if (other.CompareTag("Barrier")) {
            rbVelocity = 0f;
            Debug.Log(rbVelocity);
        }
    } 
}