using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSwap : MonoBehaviour
{
    //Player gameobjects
    public GameObject char1;
    public GameObject char2;
    
    //player1 components
    public CharacterController char1control;
    public Camera char1cam;
    public CameraController char1camcontrol;
    public Rigidbody char1rbody;

    //player2 components
    public CharacterController1 char2control;
    public Camera char2cam;
    public SimpleSmoothMouseLook char2camcontrol;
    public Rigidbody char2rbody;

    //swapping variables
    public int character = 1;
    public float swapTimer = 0;
    public float swapDist;

    //UI elements
    public GameObject char1Canvas;
    public GameObject char2Canvas;
    public Image redWifiImage;
    public Image blueWifiImage;
    public Sprite[] redWifiSignal;
    public Sprite[] blueWifiSignal;
    public int wifiStrength;

    //Audio
    private AudioManager audioManager;
    public AudioSource morteAudioSource;
    public AudioSource msmrAudioSource;
    public AudioClip[] morteAudioClips;
    public AudioClip[] msmrAudioClips;

    //Random number for voicelines
    private System.Random random = new System.Random();
    public float timer;
    [Header("Frequency of random voice lines (in seconds)")]
    public int frequency;


    // Start is called before the first frame update
    void Start()
    {
        //Assigning variables to their respective components
        audioManager = FindObjectOfType<AudioManager>();

        //player1 components
        char1control = char1.GetComponent<CharacterController>();
        char1cam = char1.GetComponentInChildren<Camera>();
        char1camcontrol = char1.GetComponentInChildren<CameraController>();
        char1rbody = char1.GetComponent<Rigidbody>();

        //player2 components
        char2control = char2.GetComponent<CharacterController1>();
        char2cam = char2.GetComponentInChildren<Camera>();
        char2camcontrol = char2.GetComponentInChildren<SimpleSmoothMouseLook>();
        char2rbody = char2.GetComponent<Rigidbody>();

        //Turn off player2
        char2control.enabled = false;
        char2cam.enabled = false;
        char2camcontrol.enabled = false;

        //Assign UI variables
        char1Canvas = GameObject.Find("Canvas MORTE");
        char2Canvas = GameObject.Find("Canvas MSMR");
        redWifiImage = GameObject.Find("RedWifi").GetComponent<Image>();
        blueWifiImage = GameObject.Find("BlueWifi").GetComponent<Image>();

        //Turn off player2 UI
        char2Canvas.SetActive(false);

        //Assign audio
        audioManager.Play("MORTE Walking");

        morteAudioSource = GameObject.Find("Char1").GetComponent<AudioSource>();
        msmrAudioSource = GameObject.Find("Char2").GetComponent<AudioSource>();

        morteAudioSource.volume = 0.5f;
        msmrAudioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Finds the distance between the two players
        swapDist = Vector3.Distance(char1.transform.position, char2.transform.position);

        timer += Time.deltaTime;

        //Creates a countdown timer to stop swapping too quickly
        if (swapTimer > 0) {
            swapTimer -= Time.deltaTime;
        }
        else if (swapTimer <= 0)
        {
            swapTimer = 0;
        }

        //Morte ----> MSMR
        if (Input.GetButton("Fire2") && character == 1 && swapTimer == 0 && swapDist <= 65 )
        {
            //Switch off player 1
            char1control.enabled = false;
            char1cam.enabled = false;
            char1camcontrol.enabled = false;
            char1rbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

            //Switch on player 2
            char2control.enabled = true;
            char2cam.enabled = true;
            char2camcontrol.enabled = true;
            char2rbody.constraints = RigidbodyConstraints.None;
            char2rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            character = 2;
            swapTimer = 2;

            audioManager.Stop("MORTE Walking");
            audioManager.Play("MORTE Walking End");

            //Swap UI
            char1Canvas.SetActive(false);
            char2Canvas.SetActive(true);

            int chooseChar = random.Next(1, 4);
            //Morte Speaks
            if (chooseChar == 1)
            {
                int chooseClip = random.Next(6, 9);
                if (chooseClip == 6 || chooseClip == 7)
                {
                    morteAudioSource.PlayOneShot(morteAudioClips[chooseClip]);
                }
            }
            //MSMR Speaks
            else if (chooseChar == 2)
            {
                int chooseClip = random.Next(5, 8);
                msmrAudioSource.PlayOneShot(msmrAudioClips[chooseClip]);
            }


        }

        //MSMR ----> Morte
        else if (Input.GetButton("Fire2") && character == 2 && swapTimer == 0 && swapDist <= 65)
        {
            //Switch on player 1
            char1control.enabled = true;
            char1cam.enabled = true;
            char1camcontrol.enabled = true;
            char1rbody.constraints = RigidbodyConstraints.None;
            char1rbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            //Switch off player 2
            char2control.enabled = false;
            char2cam.enabled = false;
            char2camcontrol.enabled = false;
            char2rbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

            character = 1;
            swapTimer = 2;

            audioManager.Play("MORTE Walking");
            audioManager.Play("MSMR Walking");

            char1Canvas.SetActive(true);
            char2Canvas.SetActive(false);

            int chooseChar = random.Next(1, 4);
            //Morte Speaks
            if (chooseChar == 1)
            {
                int chooseClip = random.Next(8, 10);
                morteAudioSource.PlayOneShot(morteAudioClips[chooseClip]);
            }
            //MSMR Speaks
            else if (chooseChar == 2)
            {
                int chooseClip = random.Next(4, 6);
                if (chooseClip == 4)
                {
                    msmrAudioSource.PlayOneShot(msmrAudioClips[chooseClip]);
                }

            }



        }

        //Update UI wifi bar based on player distance
        if (swapDist > 65)
        {
            wifiStrength = 0;
        }
        else if (swapDist > 48)
        {
            wifiStrength = 1;
        }
        else if (swapDist > 32)
        {
            wifiStrength = 2;
        }
        else if (swapDist > 16)
        {
            wifiStrength = 3;
        }
        else if (swapDist <= 16)
        {
            wifiStrength = 4;
        }


        redWifiImage.sprite = redWifiSignal[wifiStrength];
        blueWifiImage.sprite = blueWifiSignal[wifiStrength];


    }

    void LateUpdate()
    {
        //Playing random voicelines using frequency for how often voice clips will randomise
        if (Mathf.RoundToInt(timer) == frequency)
        {
            timer = 0;
            int chooseClip = random.Next(0, 4);
            int chooseChar = random.Next(1, 3);
            if(chooseChar == 1)
            {
                morteAudioSource.PlayOneShot(morteAudioClips[chooseClip]);
            }
            else if (chooseChar == 2)
            {
                msmrAudioSource.PlayOneShot(msmrAudioClips[chooseClip]);
            }
        }
        
    }
}
