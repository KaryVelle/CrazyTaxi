using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SteeringBehavior : MonoBehaviour
{
    public float speed;
    public Vector3 desiredVelocity { get; set; }
    public Vector3 velocity { get; set; }
    public Vector3 position { get; set; } 
    public Vector3 target { get; set; }

    public abstract Vector3 GetForce();
    
}
