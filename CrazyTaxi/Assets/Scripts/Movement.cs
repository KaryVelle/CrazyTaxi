using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float rotDegrees = 0.5f;
    [SerializeField] public Rigidbody cabinRigidbody;
    [SerializeField] private Vector3 relativeFwd;
    [SerializeField] public float acceleration;
    [SerializeField] public float deacceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speed;
    public bool playerHasControl;
    public float minRotZ;
    public float maxRotZ;
    public float rotZ;
    private float currentSpeed = 0.0f;

    void FixedUpdate()
    {
        relativeFwd = cabinRigidbody.transform.TransformDirection(Vector3.forward);
        if (playerHasControl)
        {
            if (Input.GetKey("w"))
                cabinRigidbody.transform.Rotate(-rotDegrees, 0, rotZ);

            if (Input.GetKey("s"))
            {
                cabinRigidbody.transform.Rotate(rotDegrees, 0, rotZ);
            }

            if (Input.GetKey("d"))
            {
                cabinRigidbody.transform.Rotate(0, rotDegrees, rotZ);

            }

            if (Input.GetKey("a"))
            {
                cabinRigidbody.transform.Rotate(0, -rotDegrees, rotZ);
            }

            if (Input.GetKey("space"))
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.fixedDeltaTime);
                cabinRigidbody.velocity = relativeFwd * speed * currentSpeed;
            }
            else
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deacceleration * Time.fixedDeltaTime);
                cabinRigidbody.velocity = relativeFwd * speed * currentSpeed;
            }

            if (Input.GetKey("q"))
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.fixedDeltaTime);
                cabinRigidbody.velocity = relativeFwd * speed * currentSpeed * -1;
            }

            if (Input.GetKeyUp("q"))
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deacceleration * Time.fixedDeltaTime);
                cabinRigidbody.velocity = relativeFwd * speed * currentSpeed *-1;
            }

            if (Input.GetKey("e"))
            {
                currentSpeed = 0;
                cabinRigidbody.velocity = relativeFwd * speed * currentSpeed;
            }
        }
    }
}

