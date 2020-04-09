using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSwap : MonoBehaviour
{

    public GameObject char1;
    public GameObject char2;
    public int character = 1;
    public float swapTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        char1.gameObject.SetActive(true);
        char2.gameObject.SetActive(false);
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
            char1.gameObject.SetActive(false);
            char2.gameObject.SetActive(true);

            character = 2;
            swapTimer = 2;
        }
        else if (Input.GetButton("Fire1") && character == 2 && swapTimer == 0)
        {
            char1.gameObject.SetActive(true);
            char2.gameObject.SetActive(false);

            character = 1;
            swapTimer = 2;
        }
    }
}
