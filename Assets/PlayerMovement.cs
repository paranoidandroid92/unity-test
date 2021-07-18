using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpForce = 200;
    public float rotationAngle = 3;
    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, movementSpeed);
            updateFacingDirection();
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, -movementSpeed);
            updateFacingDirection();
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.velocity = new Vector3(-movementSpeed, body.velocity.y, body.velocity.z);
            updateFacingDirection();
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.velocity = new Vector3(movementSpeed, body.velocity.y, body.velocity.z);
            updateFacingDirection();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -rotationAngle, 0));
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, rotationAngle, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(new Vector3(0, jumpForce, 0));
        }

       
    }

    private void updateFacingDirection()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(body.velocity), Time.deltaTime * 5f);
    }
}
