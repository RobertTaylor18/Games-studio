using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateLift : MonoBehaviour
{
    //Defining variables for other objects/components
    public Transform theDest;
    public CharSwap swapScript;
    public Rigidbody playerRB;
   
    //Variables collected from the crate itself
    public Rigidbody rBody;
    public Renderer crateRenderer;
    public bool isColliding;

    //Variables for audio
    public AudioClip audioClip;
    AudioSource audioSource;


    void Start()
    {
        //Collecting other objects/components and containing them in variables
        rBody = GetComponent<Rigidbody>();
        swapScript = GameObject.Find("Player").GetComponent<CharSwap>();

        crateRenderer = this.GetComponent<Renderer>();

        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
        audioSource.volume = 0.1f;
    }



    void OnMouseDown()
    {
        //if the forklift player is used and they are clicking on the cube while colliding with it
        if (swapScript.character == 1 & isColliding) {

            //Constrains the crate while moving it to another layer
            rBody.gameObject.layer = 10;
            rBody.useGravity = false;
            rBody.constraints = RigidbodyConstraints.FreezeAll;

            //Moves the crate to a position in front of the player and sets it as a child
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.2f, this.transform.position.z);
            this.transform.parent = GameObject.Find("Destination").transform;

            //Adds transparency to crate
            Color tempColor = crateRenderer.material.color;
            tempColor.a = 0.25f;
            crateRenderer.material.color = tempColor;
        }
    }

    void OnMouseUp()
    {
        //Reverses constraints and returns the crate to original layer
        rBody.gameObject.layer = 11;
        
        rBody.useGravity = true;
        rBody.constraints = RigidbodyConstraints.None;
        rBody.constraints = RigidbodyConstraints.FreezeRotation;

        //Changes the parent back to the original
        this.transform.parent = GameObject.Find("Props").transform;

        //Undo the transparency
        Color tempColor = crateRenderer.material.color;
        tempColor.a = 1;
        crateRenderer.material.color = tempColor;
    }

    //If other objects are colliding with the crate, then fire the audio
    void OnCollisionEnter(Collision collision)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip, 1);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fork")
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
