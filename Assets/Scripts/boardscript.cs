using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class boardscript : MonoBehaviour
{
    public float moveSpeed;
    void Start()
    {
        //GameObject river = GameObject.Find("River");
        //Destroy(gameObject, 4.5f);
        //Destroy(river);
            //Instantiate(river, river.transform.position, river.transform.rotation);
        Destroy(gameObject, 3.2f);
            
    }

    
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(null);
        }
    }
    
}
