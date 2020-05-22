using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public bool activated = false;
    public float movingSpeed;

    public GameObject ramp;
    public Transform leverHandel;
    public GameObject MSMR;



    public SelectionManager selectionManager;

    void Start()
    {
        selectionManager = MSMR.GetComponent<SelectionManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (selectionManager._selection == leverHandel)
        {
            if (Input.GetKeyDown("e"))
            {
                if (!activated)
                {
                    activated = true;
                }
                else if (activated)
                {
                    activated = false;
                }
            }
        }



        movingSpeed = Mathf.Clamp(1f, 1f, 5f * Time.deltaTime);

        if (ramp.transform.position.y > 1.19)
        {
            movingSpeed = 0;
        }

        if (activated == true)
        {
            ramp.transform.Translate(-movingSpeed, 0, 0);
        }
        else
        {
            ramp.transform.position = new Vector3(106.7477f, -4f, 30f);
        }
    }

}
