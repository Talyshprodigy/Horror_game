using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float thrust;
    public float moveSpeed;
    public Vector3 localPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        localPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * thrust);
            transform.Translate(transform.forward * moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(transform.up * thrust);
            transform.Translate(-transform.forward * moveSpeed);
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(transform.up * thrust);
            transform.Translate(transform.forward * moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-transform.right * moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(transform.right * moveSpeed);
        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Car"))
        {
            print("game over");
            transform.position = localPosition;
        }
    }
}
