using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSwap : MonoBehaviour
{

    public GameObject char1;
    public GameObject char2;
    
    public CharacterController char1control;
    //public FirstPersonController char1script;
    public Camera char1cam;
    
    public CharacterController1 char2control;
   // public FirstPersonController char2script;
    public Camera char2cam;

    public int character = 1;
    public float swapTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // char1.gameObject.SetActive(true);
        // char2.gameObject.SetActive(false);

        char1control = char1.GetComponent<CharacterController>();
       // char1script = char1.GetComponent<FirstPersonController>();
        char1cam = char1.GetComponentInChildren<Camera>();
        
        char2control = char2.GetComponent<CharacterController1>();
      //  char2script = char2.GetComponent<FirstPersonController>();
        char2cam = char2.GetComponentInChildren<Camera>();


        // char1.gameObject.SetActive(true);
        //char2.gameObject.SetActive(false);


        char2control.enabled = false;
        char2cam.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (swapTimer > 0) {
            swapTimer -= Time.deltaTime;
        }
        else if (swapTimer <= 0)
        {
            swapTimer = 0;
        }

        if (Input.GetButton("Fire1") && character == 1 && swapTimer == 0)
        {
            char1control.enabled = false;
            char1cam.enabled = false;
            
            char2control.enabled = true;
            char2cam.enabled = true;

            character = 2;
            swapTimer = 2;
        }
        else if (Input.GetButton("Fire1") && character == 2 && swapTimer == 0)
        {
            char1control.enabled = true;
            char1cam.enabled = true;

            char2control.enabled = false;
            char2cam.enabled = false;

            character = 1;
            swapTimer = 2;
        }
    }
}
