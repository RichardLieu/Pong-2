using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddle : MonoBehaviour
{
    public float unitsPerSecond = 3f;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Transform t = GetComponent<Transform>();
            t.position += Vector3.left * unitsPerSecond * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            Transform t = GetComponent<Transform>();
            t.position += Vector3.right * unitsPerSecond * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        BoxCollider bc = GetComponent<BoxCollider>();
        Bounds bounds = bc.bounds;
        float maxX = bounds.max.x;
        float minX = bounds.min.x;

        Quaternion rotation = Quaternion.Euler(0f, 0f, 60f);
        Vector3 bounceDirection = rotation * Vector3.up;

        Rigidbody rb = collision.rigidbody;
        rb.AddForce(bounceDirection * 1000f, ForceMode.Force);
    }
}
