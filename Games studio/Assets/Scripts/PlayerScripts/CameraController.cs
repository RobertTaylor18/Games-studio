using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //Adapted from a third person orbital camera, this is why there is offset and xtilt controls
    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 1, -2);
    public float xTilt = 10;

    Vector3 destination = Vector3.zero;
    CharacterController charController;

    //Defining main components for mouselook
    float rotateVel = 0;
    float vertical;
    float rotSpeed = 4.0f;

    public GameObject player;


    void Start()
    {
        SetCameraTarget(target);

        //Hides cursor and locks it to the center allowing for a crosshair for interactions
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void SetCameraTarget(Transform t) //Passes in the transform set in the editor
    {
        //Ensures targeted character script is gathered
        if (target != null)
        {
            if (target.GetComponent<CharacterController>())
            {
                charController = target.GetComponent<CharacterController>();
            }
            else
                Debug.LogError("The camera's target needs a character controller.");
        }
        else
        {
            Debug.LogError("Your camera needs a target.");
        }
    }

    void Update()
    {
        //Collecting mouse input
        var mouseVertical = Input.GetAxis("Mouse Y");

        //Calculating the rotation to apply based on input relative to 360 degrees
        vertical = (vertical - rotSpeed * mouseVertical) % 360f;

        //Clamps on the vertical to provide a min and max angle when looking up or down
        vertical = Mathf.Clamp(vertical, -30, 60);

        //Applies rotation to camera transform acting around the x axis
        transform.localRotation = Quaternion.AngleAxis(vertical, Vector3.right);
    }

    void LateUpdate()
    {
        //Using late update ensures these function fire after the current rotation has been updated
        MoveToTarget();

        LookAtTarget();
    }

    void MoveToTarget()
    {
        //Moves camera to position slightly offset from the character (in this case offset is zero)
        destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;

    }

    void LookAtTarget()
    {
        //Smooths rotation over time by gradually tending towards a given value
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
    }
}
