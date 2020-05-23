using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    public int checkpoint;
    public GameObject pointLocation;
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointLocation = GameObject.Find("Checkpoint" + checkpoint);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.transform.position = pointLocation.transform.position;
        }
    }
}
