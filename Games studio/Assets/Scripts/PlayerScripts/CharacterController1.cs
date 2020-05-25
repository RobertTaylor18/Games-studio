using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController1 : MonoBehaviour
{
    public Rigidbody rBody;
    public float inputDelay, forwardVel, jumpForce, fallMultiplier;
    float forwardInput, sideInput;
    private bool playedOnce = false;

    public bool isGrounded = false;
    public Transform groundCheck;
    public float groundRadius = .1f;
    public LayerMask Ground;
    public float jumpCount;
    public AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        GetInput();
    }

    void FixedUpdate()
    {
        Run();
        

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

            if (!playedOnce)
            {
                audioManager.Play("MSMR Walking");
                playedOnce = true;
            }

           
        }
        else
        {
            //rBody.velocity = Vector3.zero;
            rBody.velocity = new Vector3(0, rBody.velocity.y, 0);
            rBody.position = rBody.position;

            audioManager.Stop("MSMR Walking");
            playedOnce = false;
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
