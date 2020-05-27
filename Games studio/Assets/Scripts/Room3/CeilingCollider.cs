using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCollider : MonoBehaviour
{
    public bool colliding = false;
    public string objectTag = "Untagged";
    public GameObject objectGameObject;

    //These two functions get the name and tag of the colliding object of the object that this script is attacked to.
    //This is done to send this infomation to other scripts
    void OnCollisionEnter(Collision collision)
    {
        colliding = true;
        objectTag = collision.gameObject.tag;
        objectGameObject = collision.gameObject;

    }

    void OnCollisionExit(Collision collision)
    {
        colliding = false;
        objectTag = "Untagged";
        objectGameObject = null;
    }

}
