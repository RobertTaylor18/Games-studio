using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController1 : MonoBehaviour
{
    public Rigidbody rBody;
    public float inputDelay, forwardVel, jumpForce, fallMultiplier;
    float forwardInput, sideInput;
    public float grav, fallgrav;

    public Vector3 Mag;

    public bool isGrounded = false;
    public Transform groundCheck;
    public float groundRadius = .1f;
    public LayerMask Ground;
    public float jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Mag = rBody.velocity;
        GetInput();

        grav = Physics.gravity.y;

        if (rBody.velocity.y < 0)
        {

            //rBody.velocity += new Vector3 (0f,-9.81f * fallMultiplier,0f);
            // rBody.AddForce(0f,-9.81f,0f);
            //rBody.AddForce(Vector3.up * Physics.gravity.y * fallMultiplier);
        }
        fallgrav = rBody.velocity.y;
    }

    void FixedUpdate()
    {
        Run();
        Jump();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, Ground);

        if (isGrounded)
        {
            jumpCount = 0;
        }
        
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");
    }

    void Run()
    {
        
        if (Mathf.Abs(forwardInput) > inputDelay || Mathf.Abs(sideInput) > inputDelay)
        {
            Vector3 temp = (transform.forward * forwardInput * forwardVel) + (transform.right * sideInput * forwardVel);
            rBody.velocity = new Vector3(temp.x, rBody.velocity.y, temp.z);
            //rBody.velocity = (transform.forward * forwardInput * forwardVel) + (transform.right * sideInput * forwardVel);

            //Sprint
            if (Input.GetButtonDown("Fire3"))
             {
                 rBody.velocity = (transform.forward * forwardInput * forwardVel * 2) + (transform.right * sideInput * forwardVel * 2);
             }

            /*
            if (Input.GetButtonDown("Fire3"))
            {
                rBody.velocity = new Vector3(sideInput*100, rBody.velocity.y, forwardInput * 100); 
            }*/
           
        }
        else
        {
            //rBody.velocity = Vector3.zero;
            rBody.velocity = new Vector3(0, rBody.velocity.y, 0);


            rBody.position = rBody.position;
        }

       /* if (Input.GetButtonDown("Fire3") && (Mathf.Abs(forwardInput) > 0 || Mathf.Abs(sideInput) > 0))
        {
            if (forwardInput >)
            rBody.velocity = (transform.forward * forwardInput * forwardVel * 2) + (transform.right * sideInput * forwardVel * 2);
        }*/
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < 1)
        {
            rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //rBody.velocity = new Vector3(0f,jumpForce,0f);
            jumpCount++;
        }
    }
}
