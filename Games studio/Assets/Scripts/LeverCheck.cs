using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool activated = false;
    public GameObject p2;
    public GameObject door;
    public PlateCheck p2Script;
    public float doorSpeed;

    // Start is called before the first frame update
    void Start()
    {
        p2Script = p2.GetComponent<PlateCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        doorSpeed = Mathf.Clamp(2 * Time.deltaTime, 0f, 5f);

        if (door.transform.position.x > 16)
        {
            doorSpeed = 0;
        }

        if (activated == true && p2Script.isActive == true)
        {
            door.transform.Translate(doorSpeed, 0, 0);
        }
        else
        {
            door.transform.position = new Vector3(10f, 1.2f, 7f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        activated = true;
    }
    
    void OnTriggerExit(Collider other)
    {
        activated = false;
        door.transform.Translate(-10, 0, 0);
    }
}
