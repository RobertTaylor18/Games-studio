using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool activated = false;
    public GameObject p2;
    public GameObject door;
    public PlateCheck p2Script;
    public float doorSpeed;

    public AudioClip audioClip;
    AudioSource audioSource;
    private bool playedOnce = false;

    public int plateId;

    // Gathering all the components for refernecing needed in this script
    void Start()
    {
        p2Script = p2.GetComponent<PlateCheck>();
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
        //This will check if the pressure plate is active and will play a sound
        if (activated & !playedOnce)
        {
            playedOnce = true;
            audioSource.PlayOneShot(audioClip, 1);
        }
        if (!activated)
        {
            playedOnce = false;
        }


        //Here we check if both pressure plates have been activated and will open a door if true.
        if (activated == true && p2Script.isActive == true)
        {
            if (plateId == 1)
            {
                doorSpeed = Mathf.Clamp(2 * Time.deltaTime, 0f, 2f);

                if (door.transform.position.x > 16)
                {
                    doorSpeed = 0;
                }
                door.transform.Translate(doorSpeed, 0, 0);
            }
            else if (plateId == 2)
            {
                doorSpeed = Mathf.Clamp(2 * Time.deltaTime, 0f, 5f);
                
                if (door.transform.position.z < -39)
                {
                    doorSpeed = 0;
                }
                door.transform.Translate(doorSpeed, 0, 0);
            }
        }
        //If both pressure plates arent active then this will close the door
        else
        {
            if (plateId == 1)
            {
                door.transform.position = new Vector3(10f, 1.2f, 7f);
            }
            else if (plateId == 2)
            {
                door.transform.position = new Vector3(7f, 7.5f, -31f);
            }
        }
    }

    //These two functions are checking whether or not any object is in the pressure plates trigger boundry
    void OnTriggerStay(Collider other)
    {
        activated = true;
    }
    
    void OnTriggerExit(Collider other)
    {
        activated = false;
    }
}
