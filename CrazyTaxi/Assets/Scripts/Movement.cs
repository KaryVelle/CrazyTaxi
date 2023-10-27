using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float rotDegrees = 0.5f;
    [SerializeField] public Rigidbody cabinRigidbody;
    [SerializeField] private Vector3 relativeFwd;
    [SerializeField] public float speed;
    [SerializeField] private float maxSpeed;
    public bool playerHasControl;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        relativeFwd = cabinRigidbody.transform.TransformDirection(Vector3.forward);
        if (playerHasControl)
        {
            if (Input.GetKey("w"))
                cabinRigidbody.transform.Rotate(-rotDegrees,0,0);

            if ( Input.GetKey("s"))
            {
                cabinRigidbody.transform.Rotate(rotDegrees,0,0);
            }

            if (Input.GetKey("d"))
            {
                cabinRigidbody.transform.Rotate(0, rotDegrees,0);  

            }

            if (Input.GetKey("a"))
            {
                cabinRigidbody.transform.Rotate(0, -rotDegrees,0); 
            }

            if (Input.GetKey("space"))
            {
                cabinRigidbody.velocity = relativeFwd * speed * maxSpeed;
            }
           
            if (Input.GetKeyUp("space"))
            {
                cabinRigidbody.velocity = relativeFwd * speed * maxSpeed / 2;
            }
            
            if (Input.GetKey("q"))
            {
                cabinRigidbody.velocity = relativeFwd * speed * maxSpeed *-1;
            }
           
            if (Input.GetKeyUp("q"))
            {
                cabinRigidbody.velocity = relativeFwd * speed * maxSpeed *-1 / 2;
            }

            if (Input.GetKey("e"))
            {
                cabinRigidbody.velocity = Vector3.zero;
            } 
        }
    }
}
