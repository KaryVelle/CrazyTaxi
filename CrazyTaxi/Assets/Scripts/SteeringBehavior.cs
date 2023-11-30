using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SteeringBehavior : MonoBehaviour
{
    public float speed;
    public Vector3 DesiredVelocity { get; set; }
    public Vector3 Velocity { get; set; }
    public Vector3 Position { get; set; } 
    public Vector3 Target { get; set; }

    public abstract Vector3 GetForce();
    
}
