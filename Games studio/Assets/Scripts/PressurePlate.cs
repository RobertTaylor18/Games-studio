using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool activated = false;
    public GameObject p2;
    public GameObject door;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        activated = true;
        door.transform.Translate(10,0,0);
    }
    
    void OnTriggerExit(Collider other)
    {
        activated = false;
        door.transform.Translate(-10, 0, 0);
    }
}
