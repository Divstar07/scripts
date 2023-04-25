
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference the rigid body
    private Rigidbody playerRb;
    public float moveSpeedV;
    public float moveSpeedH;
    public float jumpForce;
    public float gravityModifier;
    private int jumpCount = 2;
    public bool isOnGround;
    public bool isJumping;
    public bool canJump;
    public float speedReduction;
    public float origV;
    public float origH;
    private GameObject cam2;
    // Start is called before the first frame update
    void Start()
    {
        // Get the rigid body component
        playerRb = GetComponent<Rigidbody>();
        // Modify the gravity based on the gravity modifier
        Physics.gravity *= gravityModifier;
        cam2 = GameObject.Find("Cam2");
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input
        float verticalInput = Input.GetAxis("Vertical") * moveSpeedV;
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeedH;

       
        // Fix the double speed if moving both horizontal and vertical
       if ((Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) && (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0))
        {
            Mathf.Sqrt(moveSpeedV);
            Mathf.Sqrt(moveSpeedH);
        }
        else
        {
            moveSpeedV = origV;
            moveSpeedH = origH;
        }
       
       if(Input.GetAxis("Vertical") < 0)
        {
            moveSpeedV = 5;
        }
       else
        {
            moveSpeedV = origV;
        }

        // Implement player movement
        playerRb.velocity = new Vector3(horizontalInput, playerRb.velocity.y, verticalInput);
        playerRb.velocity = transform.TransformDirection(playerRb.velocity);

        // Make the player jump
        if (Input.GetButtonDown("Jump") && (jumpCount > 0) && canJump)
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.y);
            jumpCount--;
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        // If the user presses 1, switch to cam2
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cam2.SetActive(true);
            Debug.Log("Pressed Q");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            cam2.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
            jumpCount = 2;
        isOnGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isOnGround = false;
    }
}