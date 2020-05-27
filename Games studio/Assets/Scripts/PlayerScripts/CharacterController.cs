using UnityEngine;
using System.Collections;
using System;

public class CharacterController : MonoBehaviour
{
    //Defining movement variables
    public float inputDelay = 0.1f;
    public float forwardVel;
    public float rotateVel;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;
    float horizontal;

    //Gets current target rotation
    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    //Defining camera for mouselook
    public Camera cam;

    void Start()
    {
        //sets the stored quaternion using initial rotation
        targetRotation = transform.rotation;

        //Ensures Rigidbody is connected to script
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else Debug.LogError("The Character needs a rigidbody.");

        //Setting default input values to zero
        forwardInput = turnInput = 0;

        //Setting horizontal to the rotation on the y-axis
        horizontal = transform.eulerAngles.y;
    }

    void GetInput()
    {
        //Collects forward and backward keys and horizontal mouse movement
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Mouse X")/2;
    }

    void Update()
    {
        //These functions are fired every frame to ensure up-to-date values from the player's inputs
        GetInput();
        Turn();

    }

    void FixedUpdate()
    {
        //This function runs in fixed update as it uses the physics system
        Run();
    }

    void Run()
    {
        //Input delay smooths out small unintended inputs on an axis by creating a deadzone (mainly applicable to gamepad controllers)
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //If forwards or backwards is pressed move the character in that direction relative to transform
            Vector3 temp = transform.forward * forwardInput * forwardVel;
            rBody.velocity = new Vector3(temp.x, rBody.velocity.y, temp.z);
        }
        else
        {
            //Otherwise don't move the character except for any remaining y velocity for falling
            rBody.velocity = new Vector3(0, rBody.velocity.y, 0);
        }
    }

    void Turn()
    {
        //Calculating the rotation to apply based on input relative to 360 degrees
        horizontal = (horizontal + rotateVel * turnInput) % 360f;

        //Clamping this value creates a maximum turn speed
        horizontal = Mathf.Clamp(horizontal, -3, 3);

        //Adds a damping effect so the camera spin decelerates to zero and doesnt keep spinning
        if (horizontal > 0)
        {
            horizontal -= 4 * Time.deltaTime;
        }
        else if (horizontal < 0)
        {
            horizontal += 4 * Time.deltaTime;
        }
        else
        {
            horizontal = 0;
        }

        //Applies the quaternion around the Y axis
        targetRotation *= Quaternion.AngleAxis(horizontal, Vector3.up);
        transform.rotation = targetRotation;


    }

    internal void SimpleMove(Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
