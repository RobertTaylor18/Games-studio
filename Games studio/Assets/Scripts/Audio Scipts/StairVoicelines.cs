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
        audioSource = GameObject.Find("Char1").GetComponent<AudioSource>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered)
        {
            int chooseClip = random.Next(0, 2);
            hasTriggered = true;
            audioSource.PlayOneShot(audioManager.getClip(audioClips[chooseClip]));
        }
    }

}
