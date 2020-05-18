using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController1 : MonoBehaviour
{
    public Rigidbody rBody;
    public float inputDelay, forwardVel;
    float forwardInput, sideInput;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();   
    }

    void FixedUpdate()
    {
        Run();
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
    }
}
