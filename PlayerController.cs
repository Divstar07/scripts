using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public groundCheck groundCheck;
    // Reference the rigid body
    private Rigidbody playerRb;
    public float moveSpeed;
    public float jumpForce;
    public float gravityModifier;
    private int jumpCount = 2;



    //private bool isOnGround;
    // Start is called before the first frame update
    void Start()
    {
        // Get the rigid body component
        playerRb = GetComponent<Rigidbody>();
        // Modify the gravity based on the gravity modifier
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        //playerRb.velocity = new Vector3(horizontalInput, playerRb.velocity.y, verticalInput);
        Vector3 locVel = transform.InverseTransformDirection(playerRb.velocity);
        locVel.x = horizontalInput;
        locVel.z = verticalInput;
        playerRb.velocity = transform.TransformDirection(locVel) * moveSpeed;



        //playerRb.velocity.Normalize();
        //playerRb.velocity = transform.TransformDirection(playerRb.velocity);
       // playerRb.velocity = playerRb.velocity.normalized;



        // Make the player jump
        if (Input.GetButtonDown("Jump") && groundCheck.isOnGround == true)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.y);
            jumpCount--;
        }
       

    }

   /* private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 2;
            //isOnGround = true;
        }
    } */
}
