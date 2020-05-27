using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    [SerializeField] private Animator myAnimationContoller;

    public bool activated = false;
    public float movingSpeed;

    public GameObject ramp;
    public Transform leverHandel;
    public GameObject MSMR;

    public AudioClip audioClip;
    AudioSource audioSource;



    public SelectionManager selectionManager;

    // Gathering all the components for refernecing needed in this script
    void Start()
    {
        selectionManager = MSMR.GetComponent<SelectionManager>();

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
                    activated = true;
                    myAnimationContoller.SetBool("leverActive", true);
                }
                else if (activated)
                {
                    activated = false;
                    myAnimationContoller.SetBool("leverActive", false);
                }
            }
        }


        //Setting the speed at which the chosen object will move
        movingSpeed = Mathf.Clamp(1f, 1f, 5f * Time.deltaTime);

        //Here we check if we should be moving the object and making sure it does not go too far
        if (ramp.transform.position.y > 1.15)
        {
            movingSpeed = 0;
        }
        if (activated == true)
        {
            ramp.transform.Translate(-movingSpeed, 0, 0);
        }
        //Puts object back to its orginal position
        else
        {
            ramp.transform.position = new Vector3(105.7477f, -4f, 30.79f);
        }
    }

}
