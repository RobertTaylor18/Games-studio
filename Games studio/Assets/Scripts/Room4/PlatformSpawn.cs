using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public bool activated = false;
    public GameObject platform;

    public AudioClip audioClip;
    AudioSource audioSource;
    private bool playedOnce = false;

    // Gathering all the audio components for refernecing needed in this script
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }


    void Update()
    {
        // Check if the pressure plate has been activated and play a sound if so
        if (activated & !playedOnce)
        {
            playedOnce = true;
            audioSource.pitch = 1f;
            audioSource.PlayOneShot(audioClip, 1);
        }
        if (!activated)
        {
            playedOnce = false;

        }
    }

    // Activate or deactivate the pressure plate when stood on
    void OnTriggerStay(Collider other)
    {
        activated = true;
        platform.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        activated = false;
        platform.SetActive(false);
    }
}
