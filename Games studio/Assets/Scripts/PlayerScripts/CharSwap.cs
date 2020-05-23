using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSwap : MonoBehaviour
{

    public GameObject char1;
    public GameObject char2;
    
    public CharacterController char1control;
    public Camera char1cam;
    public CameraController char1camcontrol;
    public Rigidbody char1rbody;

    public CharacterController1 char2control;
    public Camera char2cam;
    public SimpleSmoothMouseLook char2camcontrol;
    public Rigidbody char2rbody;

    public int character = 1;
    public float swapTimer = 0;
    public float swapDist;

    // Start is called before the first frame update
    void Start()
    {
        // char1.gameObject.SetActive(true);
        // char2.gameObject.SetActive(false);

        char1control = char1.GetComponent<CharacterController>();
        char1cam = char1.GetComponentInChildren<Camera>();
        char1camcontrol = char1.GetComponentInChildren<CameraController>();
        char1rbody = char1.GetComponent<Rigidbody>();

        char2control = char2.GetComponent<CharacterController1>();
        char2cam = char2.GetComponentInChildren<Camera>();
        char2camcontrol = char2.GetComponentInChildren<SimpleSmoothMouseLook>();
        char2rbody = char2.GetComponent<Rigidbody>();
        // char1.gameObject.SetActive(true);
        //char2.gameObject.SetActive(false);


        char2control.enabled = false;
        char2cam.enabled = false;
        char2camcontrol.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        swapDist = Vector3.Distance(char1.transform.position, char2.transform.position);

        if (swapTimer > 0) {
            swapTimer -= Time.deltaTime;
        }
        else if (swapTimer <= 0)
        {
            swapTimer = 0;
        }

        if (Input.GetButton("Fire2") && character == 1 && swapTimer == 0 && swapDist <= 65 )
        {
            char1control.enabled = false;
            char1cam.enabled = false;
            char1camcontrol.enabled = false;
            char1rbody.constraints = RigidbodyConstraints.FreezeAll;
            
            char2control.enabled = true;
            char2cam.enabled = true;
            char2camcontrol.enabled = true;
            char2rbody.constraints = RigidbodyConstraints.None;
            char2rbody.constraints = RigidbodyConstraints.FreezeRotationX & RigidbodyConstraints.FreezeRotationZ;

            character = 2;
            swapTimer = 2;
        }
        else if (Input.GetButton("Fire2") && character == 2 && swapTimer == 0 && swapDist <= 65)
        {
            char1control.enabled = true;
            char1cam.enabled = true;
            char1camcontrol.enabled = true;
            char1rbody.constraints = RigidbodyConstraints.None;
            char1rbody.constraints = RigidbodyConstraints.FreezeRotationX & RigidbodyConstraints.FreezeRotationZ;

            char2control.enabled = false;
            char2cam.enabled = false;
            char2camcontrol.enabled = false;
            char2rbody.constraints = RigidbodyConstraints.FreezeAll;

            character = 1;
            swapTimer = 2;
        }
    }
}
