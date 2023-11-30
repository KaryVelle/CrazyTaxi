using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorController : MonoBehaviour
{
    public List<SteeringBehavior> behaviors = new List<SteeringBehavior>();
    public Rigidbody rigidBody;
    public Vector3 velocity;
    public Vector3 totalForce = Vector3.zero;

    void FixedUpdate()
    {
        totalForce = Vector3.zero;
        
        foreach ( SteeringBehavior behavior in behaviors)
        {
            behavior.position = transform.position;
            behavior.velocity = velocity;
            totalForce += behavior.GetForce();
        }

        velocity += totalForce;
        transform.position += velocity * Time.deltaTime;

    }
}
