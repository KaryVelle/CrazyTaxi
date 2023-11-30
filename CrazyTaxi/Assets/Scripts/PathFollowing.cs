using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : SteeringBehavior
{
    public List<Vector3> nodes;
    public float pathRadius;
    public bool looping;
    private int _currentNode;
    private int _pathDirection = 1;
    private float rotationSpeed = 5;

    public override Vector3 GetForce()
    {
        
        var actualPoint = nodes[_currentNode];

        if (Vector3.Distance(actualPoint, transform.position) <= pathRadius)
        {
            _currentNode += _pathDirection;

            if (looping && (_currentNode >= nodes.Count || _currentNode <0))
            {
                _pathDirection *= -1;
                _currentNode += _pathDirection;
            }
            
            if (_currentNode >= nodes.Count)
            {
                _currentNode = nodes.Count - 1;
            }
        }
        
        return Seek();
        
    }

    Vector3 Seek()
    {
        Target = nodes[_currentNode];
        DesiredVelocity = (Target - Position).normalized * speed;
        Vector3 steering = DesiredVelocity - Velocity;
        return steering;
    }
}
