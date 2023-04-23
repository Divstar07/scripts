
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
    private int jumpCount = 2;
    private bool isOnGround;
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
        float verticalInput = Input.GetAxis("Vertical") * moveSpeed;
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
        playerRb.velocity = new Vector3(horizontalInput, playerRb.velocity.y, verticalInput);
        playerRb.velocity = transform.TransformDirection(playerRb.velocity);

        // Make the player jump
        if (Input.GetButtonDown("Jump") && (jumpCount > 0) && isOnGround)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.y);
            jumpCount--;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
            jumpCount = 2;
        isOnGround = true;
    }
}