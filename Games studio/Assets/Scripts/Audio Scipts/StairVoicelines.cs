using UnityEngine.Audio;
using System;
using UnityEngine;

public class StairVoicelines : MonoBehaviour
{
    public bool hasTriggered = false;
    public AudioSource audioSource;
    public string[] audioClips = { "MORTE Stairs1", "MORTE Stairs2" };
    public AudioManager audioManager;

    private System.Random random = new System.Random();

    void Start()
    {
        // Gathering all the audio components for refernecing needed in this script
        audioSource = GameObject.Find("Char1").GetComponent<AudioSource>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();

    }

    // If player enters the trigger area. Choose at random one of two audio clips to play
    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered & other.gameObject.tag == "Player")
        {
            int chooseClip = random.Next(0, 2);
            hasTriggered = true;
            audioSource.PlayOneShot(audioManager.getClip(audioClips[chooseClip]));
        }
    }

}
