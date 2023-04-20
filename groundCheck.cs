using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{

    public Transform groundDistance;
    public float rayLength = 0.1f;
    public bool isOnGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded())
        {
            isOnGround = true;
        }
    }

    bool isGrounded()  
 {
   return Physics.Raycast(transform.position, Vector3.down, groundDistance.position.y + rayLength);
 }
}
