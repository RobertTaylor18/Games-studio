using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCheck : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource audioSource;
    public bool playedOnce = false;

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        // Gathering all the components for refernecing needed in this script
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
        //This checks if the pressure plate is being stood on and will play a sound if true
        if (isActive & !playedOnce)
        {
            playedOnce = true;
            audioSource.pitch = 1f;
            audioSource.PlayOneShot(audioClip, 1);
        }
        if (!isActive)
        {
            playedOnce = false;

        }
    }

    //These two functions are checking whether or not any object is in the pressure plates trigger boundry
    void OnTriggerStay(Collider other)
    {
        isActive = true;    
    }
    void OnTriggerExit(Collider other)
    {
        isActive = false;
    }
}

