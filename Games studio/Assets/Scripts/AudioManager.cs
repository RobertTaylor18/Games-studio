using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        // Gives us control over soundclips infomataion in the inspector
        foreach (Sound s in sounds)
        {
            s.sourse = gameObject.AddComponent<AudioSource>();
            s.sourse.clip = s.clip;

            s.sourse.volume = s.volume;
            s.sourse.pitch = s.pitch;
            s.sourse.loop = s.loop;
        }
    }

    // Starts playing music from the start of the game
    void Start()
    {
        Play("Music");
    }

    // A function to play audio by referncing its name
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "not found.");
            return;
        }
        s.sourse.Play();
    }

    // A function to stop playing audio by referncing its name
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "not found.");
            return;
        }
        s.sourse.Stop();
    }

    // A function to get the sound clip of a stored clip
    public AudioClip getClip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "not found.");
            return null;
        }
        return s.sourse.clip;
    }

}
