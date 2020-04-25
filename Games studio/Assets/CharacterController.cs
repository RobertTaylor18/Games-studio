using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{

    public float inputDelay = 0.1f;
    public float forwardVel;
    public float rotateVel;

    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    float mouseX, mouseY, vertical;
    float rotSpeed = 4.0f;

    void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();

        else Debug.LogError("The Character needs a rigidbody.");

        forwardInput = turnInput = 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Mouse X");
        //mouseX = Input.GetAxis("Mouse X");
        
    }

    void Update()
    {
        GetInput();
        Turn();
        
    }

    void FixedUpdate()
    {
        Run();
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            rBody.velocity = transform.forward * forwardInput * forwardVel;
        }
        else
        {
           // rBody.velocity = Vector3.zero;
        }

    }

    void Turn()
    {
        targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            
        }

        transform.rotation = targetRotation;

    }
}
