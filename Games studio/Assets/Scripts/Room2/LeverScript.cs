﻿using System.Collections;
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

    void Start()
    {
        selectionManager = MSMR.GetComponent<SelectionManager>();

        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }
    // Update is called once per frame



    void Update()
    {
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



        movingSpeed = Mathf.Clamp(1f, 1f, 5f * Time.deltaTime);

        if (ramp.transform.position.y > 1.15)
        {
            movingSpeed = 0;
        }

        if (activated == true)
        {
            ramp.transform.Translate(-movingSpeed, 0, 0);
        }
        else
        {
            ramp.transform.position = new Vector3(105.7477f, -4f, 30.79f);
        }
    }

}
