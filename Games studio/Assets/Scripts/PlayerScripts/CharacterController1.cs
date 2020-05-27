using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController1 : MonoBehaviour
{
    //Defining movement variables
    public Rigidbody rBody;
    public float inputDelay, forwardVel, jumpForce;
    float forwardInput, sideInput;
    
    //Defining variables for jump logic
    public bool isGrounded = false;
    public Transform groundCheck;
    public float groundRadius = .01f;
    public LayerMask Ground;
    public int jumpCount;

    //Variables for connecting the jump to the UI element
    public bool hasJumped;
    public Image jumpPillImage;
    public Sprite[] jumpPills;

    //Variables used in footstep audio
    public AudioManager audioManager;
    private bool playedOnce = false;


    // Start is called before the first frame update
    void Start()
    {
        //Fetching objects and connecting them to variables
        rBody = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
        jumpPillImage = GameObject.Find("JumpPills").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        GetInput();

        //Updates the current jumpPill sprite depending on how many jumps are left
        jumpPillImage.sprite = jumpPills[jumpCount];
    }

    void FixedUpdate()
    {
        //This function runs in fixed update as it uses the physics system
        Run();
        
        //Creates a sphere at the player's feet to check if it is colliding with the ground layer
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, Ground);

        //Sets the jump count back to zero if the player is on the ground
        if (isGrounded & !hasJumped)
        {
            jumpCount = 0;
        }
        
    }

    void GetInput()
    {
        //Collects player inputs for movement
        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");
    }

    void Run()
    {
        //Input delay smooths out small unintended inputs on an axis by creating a deadzone (mainly applicable to gamepad controllers)
        if (Mathf.Abs(forwardInput) > inputDelay || Mathf.Abs(sideInput) > inputDelay)
        {
            //If forwards or backwards or either side is pressed, move the character in that direction relative to transform
            Vector3 temp = (transform.forward * forwardInput * forwardVel) + (transform.right * sideInput * forwardVel);

            //Uses temporary vector storage so that the Y axis velocity can be maintained
            rBody.velocity = new Vector3(temp.x, rBody.velocity.y, temp.z);
            

            //Sprint
            if (Input.GetButtonDown("Fire3"))
             {
                 rBody.velocity = (transform.forward * forwardInput * forwardVel * 3) + (transform.right * sideInput * forwardVel * 3);
             }           

            //Play footstep sound if moving
            if (!playedOnce)
            {
                audioManager.Play("MSMR Walking");
                playedOnce = true;
            }

           
        }
        else
        {
            //Otherwise don't move the character except for any remaining y velocity for falling
            rBody.velocity = new Vector3(0, rBody.velocity.y, 0);
            rBody.position = rBody.position;

            //Stop playing footsteps if player is still
            audioManager.Stop("MSMR Walking");
            playedOnce = false;
        }
    }

    void Jump()
    {
        //Multiple jumps using jump count to restrict how many the player can perform
        if (Input.GetButtonDown("Jump") & jumpCount < 2)
        {
            rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
            hasJumped = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            hasJumped = false;
        }
    }
}
