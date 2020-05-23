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
        checkpoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        pointLocation = GameObject.Find("Checkpoint" + checkpoint);
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = pointLocation.transform.position;
    }
}
