using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam2Controller : MonoBehaviour
{
    public Vector3 offset;
    public GameObject dogKnight;
    // Start is called before the first frame update
    void Start()
    {
        offset = dogKnight.transform.position - gameObject.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = dogKnight.transform.position - offset;
    }
}
