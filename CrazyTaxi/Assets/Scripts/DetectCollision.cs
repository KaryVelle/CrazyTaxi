using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public Movement movement;
    public float punishTime;
    public float timer= 0;
    public float recoveryTime;
    float startTime;
    static float t = 0.0f;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            StartCoroutine(Punish());
            Debug.Log("Chocaste pendejo");
        }
        else
        {
            StartCoroutine(StopR());
        }
       
    }

    private IEnumerator Punish()
    {
        Vector3 rot = movement.transform.localEulerAngles;

        movement.playerHasControl = false;
        while ( timer < punishTime)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime; 
            movement.transform.localEulerAngles = new Vector3(0,0,Mathf.Lerp(rot.z, 0, t));
            t += 0.5f * Time.deltaTime;
            if (t > 1.0f)
            {
                t = 0.0f;
            }
        }
       
        movement.cabinRigidbody.angularVelocity = Vector3.zero;
        if (timer >= punishTime)
        {
            timer = 0;
        }
        movement.playerHasControl = true;
    }

    private IEnumerator StopR()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(3f);
        rb.constraints = RigidbodyConstraints.None;
    }
}
