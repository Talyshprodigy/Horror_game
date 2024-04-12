using System;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")] public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    public GameObject AKM;
    public AudioSource audioSourceAKM;
    public AudioListener audioListener;
    public AudioClip Gunshot;

    Rigidbody rigidbody;

    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    private void Start()
    {
        
    }

    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed,
            Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSourceAKM.PlayOneShot(Gunshot);
        }
        Ray playerRay = Camera.main.ScreenPointToRay(new Vector2(0.5f, 0.5f));
        RaycastHit hit;

        if (Physics.Raycast(playerRay, out hit, 100))
        {
            Debug.DrawLine(playerRay.origin, hit.point,Color.red);
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Key") && Input.GetKey(KeyCode.Mouse0))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        
    }
    

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("DoorOpenable"))
        {
            Animator animator = col.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Open");
            
        }
    }
}