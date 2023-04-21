using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public PlayerController controller;
    public float groundDistance;
    public float rayLength = 0.1f;
    public bool isOnGround;
    // Start is called before the first frame update
    void Start()
    {
        groundDistance = (GetComponent<CapsuleCollider>().height / 2) + rayLength;
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundDistance))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }

    }
    
   
}
