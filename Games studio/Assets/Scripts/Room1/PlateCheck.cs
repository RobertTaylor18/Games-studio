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
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
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

    void OnTriggerStay(Collider other)
    {
        isActive = true;

        
    }

    void OnTriggerExit(Collider other)
    {
        isActive = false;
    }
}

