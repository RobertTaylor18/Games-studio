using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCeiling : MonoBehaviour
{
    [SerializeField] private Animator myAnimationContoller;

    public bool activated = false;
    public float movingSpeed;

    public Rigidbody ceiling;
    public Rigidbody door;
    public Transform leverHandel;
    public GameObject MSMR;
    public GameObject temp;

    public CeilingCollider ceilingCollider;

    public SelectionManager selectionManager;

    public AudioClip audioClip;
    AudioSource audioSource;

    // Gathering all the components for refernecing needed in this script
    void Start()
    {
        selectionManager = MSMR.GetComponent<SelectionManager>();
        ceilingCollider = ceiling.GetComponent<CeilingCollider>();

        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }



    void Update()
    {
        //This is checking the object that the player is looking at, if its the correct oject and the player clicks on it a sound and animaton will play
        if (selectionManager._selection == leverHandel)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                audioSource.PlayOneShot(audioClip, 0.5f);
                if (!activated)
                {
                    myAnimationContoller.SetBool("leverActive", true);
                    activated = true;
                }
                else if (activated)
                {
                    myAnimationContoller.SetBool("leverActive", false);
                    activated = false;
                }
            }
        }

        // If the lever is activated we give the ceiling and door a velocity to move at
        if (activated)
        {
            ceiling.velocity = new Vector3(0, -1f, 0);
            door.velocity = new Vector3(4, 0, 0);
        }
        // Resetting the ceiling and door positions if the lever is deactivated
        else if (!activated)
        {
            myAnimationContoller.SetBool("leverActive", false);
            ceiling.transform.localPosition = new Vector3(95.56999f,48.9802f, -17.98616f);
            door.transform.localPosition = new Vector3(125.64f, 7.78f, 14.87f);
        }
        //Once the door has opened enough this stops it moving
        if (door.transform.localPosition.x > 132)
        {
            door.velocity = Vector3.zero;
        }
    }
}
