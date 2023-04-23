using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference the rigid body
    private Rigidbody playerRb;
    public float moveSpeed;
    public float jumpForce;
    public float gravityModifier;
    public int jumpCount;
    public bool canJump;
    //private bool isOnGround;
    // Start is called before the first frame update
    void Start()
    {
        jumpCount = 2;
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
        // Move the player with respect to their own local Coordinates
        Vector3 locVel = transform.InverseTransformDirection(playerRb.velocity);
        locVel.x = horizontalInput;
        locVel.z = verticalInput;
        playerRb.velocity = transform.TransformDirection(locVel) * moveSpeed;


        // Make the player jump
        if (Input.GetButtonDown("Jump")  && canJump && (jumpCount > 0))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        jumpCount = 2;
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;

    }
}