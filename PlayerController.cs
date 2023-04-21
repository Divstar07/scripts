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
    public int jumpCount;



    //private bool isOnGround;
    // Start is called before the first frame update
    void Start()
    {
        jumpCount = 2;
        groundCheck = GameObject.Find("Player").GetComponent<groundCheck>();
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
        Vector3 locVel = transform.InverseTransformDirection(playerRb.velocity);
        locVel.x = horizontalInput;
        locVel.z = verticalInput;
        playerRb.velocity = transform.TransformDirection(locVel) * moveSpeed;



       


        // Make the player jump
        if (Input.GetButtonDown("Jump") && (groundCheck.isOnGround == true) && (jumpCount > 0))
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.y);
            jumpCount--;
        }
       
        if (groundCheck.isOnGround == true)
        {
            jumpCount = 2;
        }
    }

 
}
