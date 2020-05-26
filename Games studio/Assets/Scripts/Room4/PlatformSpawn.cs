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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    void Update()
    {
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
