using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Create a target transform
    public Transform target;
    public Vector3 offset;
    public float rotateSpeed;
    // Get a reference to the pivot
    public Transform pivot;
    public bool useManualOffset;
    public float maxCamRotation = 45f;
    public float minCamRotation = -35f;
    public bool invertYaxis;
    // Start is called before the first frame update
    void Start()
    {
        // Make the pivot a child of the player
        pivot.parent = target;
        if (!useManualOffset)
        {
            offset = target.position - transform.position;
        }
      Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Make the pivot follow the player
        pivot.position = target.position;
        // Get Mouse X and Y input
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;
        // Rotate the player based on the X input
        target.Rotate(0, mouseX, 0);
        
        // Rotate the pivot based on the Y input
        if (invertYaxis)
        {
            pivot.Rotate(-mouseY, 0, 0);
        }
        else
        {
            pivot.Rotate(mouseY, 0, 0);
        }


        // Limit the rotation angle
        if ((pivot.rotation.eulerAngles.x > maxCamRotation) && (pivot.rotation.eulerAngles.x < 180))
        {
            pivot.rotation = Quaternion.Euler(maxCamRotation, 0, 0);
        }

        if ((pivot.rotation.eulerAngles.x < (360 + minCamRotation)) && (pivot.rotation.eulerAngles.x > 180))
        {
            pivot.rotation = Quaternion.Euler(minCamRotation, 0, 0);
        }

        // Apply the X rotation of the player and Y rotation of the pivot to the camera 
        float camYangle = target.eulerAngles.y;
        float camXangle = pivot.eulerAngles.x;
        Quaternion camRotation = Quaternion.Euler(camXangle, camYangle, 0);
        // Make the camera follow the target
        transform.position = target.position - (camRotation * offset);
        transform.LookAt(target);
    }
}
