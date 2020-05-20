using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController1 : MonoBehaviour
{
    public Rigidbody rBody;
    public float inputDelay, forwardVel, jumpForce, fallMultiplier;
    float forwardInput, sideInput;
    public float grav, fallgrav;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        grav = Physics.gravity.y;

        if (rBody.velocity.y < 0)
        {
            //rBody.velocity += new Vector3 (0f,-9.81f * fallMultiplier,0f);
            // rBody.AddForce(0f,-9.81f,0f);
             rBody.AddForce(Vector3.up * Physics.gravity.y * fallMultiplier);
        }
        fallgrav = rBody.velocity.y;
    }

    void FixedUpdate()
    {
        Run();
        Jump();
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");
    }

    void Run()
    {
        /*if (Mathf.Abs(forwardInput) > inputDelay)
        {
            rBody.velocity = transform.forward * forwardInput * forwardVel;
          //  rBody.velocity = new Vector3(rBody.velocity.x, rBody.velocity.y, forwardInput * forwardVel);
        }
        else if (Mathf.Abs(sideInput) > inputDelay)
        {
            rBody.velocity = transform.right * sideInput * forwardVel;
            // rBody.velocity = new Vector3( sideInput * forwardVel, rBody.velocity.y, rBody.velocity.z);
        }*/
        
        if (Mathf.Abs(forwardInput) > inputDelay || Mathf.Abs(sideInput) > inputDelay)
        {
            rBody.velocity = (transform.forward * forwardInput * forwardVel) + (transform.right * sideInput * forwardVel);
            // rBody.velocity = new Vector3( sideInput * forwardVel, rBody.velocity.y,  forwardInput * forwardVel);
        }
        else
        {
            rBody.velocity = Vector3.zero;
            rBody.position = rBody.position;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
           rBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
           //rBody.velocity = new Vector3(0f,jumpForce,0f);
        }
    }
}
