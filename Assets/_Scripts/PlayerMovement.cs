using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour

{   [Range(0,8000)]
    public float speed;
    [Range(0, 3600)]
    public float rotationSpeed;
    private Rigidbody rb;
    
    private Animator _animator;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    //Gets the movement inputs, adds physics, movement speed and sets the animation.
    void FixedUpdate()
    {
        float space = speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0,vertical);
      
        rb.AddRelativeForce(dir.normalized * space);

        float angle = rotationSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        rb.AddRelativeTorque(0, mouseX * angle, 0);

        _animator.SetFloat("Velocity", rb.velocity.magnitude);
 
        _animator.SetFloat("Move X", horizontal);
        _animator.SetFloat("Move Y", vertical);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetFloat("Velocity", rb.velocity.magnitude);
            speed = 6000;
        }
        else
        {
            if (Mathf.Abs(horizontal) < 0.01f && Mathf.Abs(vertical) < 0.01f)
            {
                _animator.SetFloat("Velocity", 0); speed = 1500;
            }
            else
            {
                _animator.SetFloat("Velocity", 0.15f); speed = 1500;
            }
        }



    }
}
