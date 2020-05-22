using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{

    public float inputDelay = 0.1f;
    public float forwardVel;
    public float rotateVel;
    float fallMultiplier  = 30f;

    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    float horizontal;

    public Camera cam;
    public Animator camAnim;

    void Start()
    {
        
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();

        else Debug.LogError("The Character needs a rigidbody.");

        forwardInput = turnInput = turnInput = 0;
        horizontal = transform.eulerAngles.y;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Mouse X")/2;
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
            Vector3 temp = transform.forward * forwardInput * forwardVel;
            rBody.velocity = new Vector3(temp.x, rBody.velocity.y, temp.z);
        }
        else
        {
            rBody.velocity = new Vector3(0, rBody.velocity.y, 0);

        }

    }

    void Turn()
    {
         
        horizontal = (horizontal + rotateVel * turnInput) % 360f;
        horizontal = Mathf.Clamp(horizontal, -3, 3);

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

        targetRotation *= Quaternion.AngleAxis(horizontal, Vector3.up);
        // targetRotation *= Quaternion.AngleAxis(horizontal * Time.deltaTime, Vector3.up);
        transform.rotation = targetRotation;


    }
}
