using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject,6);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(transform.forward * moveSpeed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("NonRoad"))
        {
            Destroy(gameObject);
        }
    }
    
}
