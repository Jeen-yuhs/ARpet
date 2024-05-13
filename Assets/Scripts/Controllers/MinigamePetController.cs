using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamePetController : MonoBehaviour
{    
    public float speed, jumpSpeed;
    private Rigidbody rb;
    private bool grounded;

    private void OnEnable()
    {
        //GetComponent<NeedsController>().enabled = false; //Error
    }

    private void OnDisable()
    {
       // GetComponent<NeedsController>().enabled = true; //Error
    }

    private void Update()
    {
        CheckHorizontalMovement();
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
        }
    }

    private void Jump() 
    { 
        rb.AddForce(new Vector2(0, jumpSpeed * Time.deltaTime));
    }

    private void CheckHorizontalMovement() 
    {
        if (Input.GetAxis("Horizontal") != 0) 
        { 
            rb.AddForce(new Vector2(speed * Time.deltaTime * Input.GetAxis("Horizontal"),0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.collider.CompareTag("Ground") && collision.transform.position.y + 1.5f < transform.position.y) 
        { 
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}   

