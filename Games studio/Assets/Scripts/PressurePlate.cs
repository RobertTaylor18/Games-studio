﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool activated = false;
    public GameObject p2;
    public GameObject door;
    public PlateCheck p2Script;
    public float doorSpeed;

    public int plateId;

    // Start is called before the first frame update
    void Start()
    {
        p2Script = p2.GetComponent<PlateCheck>();
    }

    // Update is called once per frame
    void Update()
    {

        

        if (door.transform.position.x > 16 || door.transform.position.z < -38)
        {
            doorSpeed = 0;
        }

        if (activated == true && p2Script.isActive == true)
        {
            if (plateId == 1)
            {
                doorSpeed = Mathf.Clamp(2 * Time.deltaTime, 0f, 5f);
                door.transform.Translate(doorSpeed, 0, 0);
            }
            else if (plateId == 2)
            {
                doorSpeed = Mathf.Clamp(2 * Time.deltaTime, 0f, 5f);
                door.transform.Translate(doorSpeed, 0, 0);
            }
        }
        else
        {
            if (plateId == 1)
            {
                door.transform.position = new Vector3(10f, 1.2f, 7f);
            }
            else if (plateId == 2)
            {
                door.transform.position = new Vector3(7f, 7.5f, -31f);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        activated = true;
    }
    
    void OnTriggerExit(Collider other)
    {
        activated = false;
       /* if (plateId == 1)
        {
            door.transform.Translate(-10, 0, 0);
        }
        else if (plateId == 2)
        {
            door.transform.Translate(10, 0, 0);
        }*/
    }
}
