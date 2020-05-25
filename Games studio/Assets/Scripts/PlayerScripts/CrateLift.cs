using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateLift : MonoBehaviour
{
    public Transform theDest;
    public CharSwap swapScript;
    public Rigidbody rBody;
    public Rigidbody playerRB;
    public Renderer crateRenderer;
    public bool isColliding;

    public AudioClip audioClip;
    AudioSource audioSource;


    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        swapScript = GameObject.Find("Player").GetComponent<CharSwap>();

        crateRenderer = this.GetComponent<Renderer>();

        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }



    void OnMouseDown()
    {
        if (swapScript.character == 1 & isColliding) {
            rBody.gameObject.layer = 10;
            rBody.useGravity = false;
            rBody.constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.2f, this.transform.position.z);
            this.transform.parent = GameObject.Find("Destination").transform;
            Color tempColor = crateRenderer.material.color;
            tempColor.a = 0.25f;
            crateRenderer.material.color = tempColor;
        }
    }

    void OnMouseUp()
    {
        rBody.gameObject.layer = 11;
        this.transform.parent = GameObject.Find("Props").transform;
        rBody.useGravity = true;
        rBody.constraints = RigidbodyConstraints.None;
        Color tempColor = crateRenderer.material.color;
        tempColor.a = 1;
        crateRenderer.material.color = tempColor;
    }


    void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(audioClip, 1);
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
