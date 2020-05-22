using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public bool activated = false;
    public GameObject platform;
  

    void OnTriggerStay(Collider other)
    {
        activated = true;
        platform.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        activated = false;
        platform.SetActive(false);
    }
}
