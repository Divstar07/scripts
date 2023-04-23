using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerController player;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player jumps cue the jumping animation
        if (player.isJumping)
        {
            playerAnim.SetTrigger("Jump");
        }
        // if the player runs forward cue the running animation
        if (Input.GetAxis("Vertical") > 0.3 && (player.isOnGround))
        {
            playerAnim.SetFloat("Run", 1);
            // Stop the running animation if the player isn't pressing vertical axis
        }else
        {
            playerAnim.SetFloat("Run", 0);
        }

        // If the player is walking backwards or sideways cue the walk slow animation
        if (Input.GetAxis("Vertical") < -0.3 || Input.GetAxis("Horizontal") > 0.3 || Input.GetAxis("Horizontal") < -0.3)
          {
              playerAnim.SetFloat("WalkSlow", 1);
          }
        else 
        {
            playerAnim.SetFloat("WalkSlow", 0);
        }

    }


}
