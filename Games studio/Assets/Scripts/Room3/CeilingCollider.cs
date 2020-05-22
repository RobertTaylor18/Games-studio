using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCollider : MonoBehaviour
{
    public bool colliding = false;
    public string objectTag = "Untagged";
    public GameObject objectGameObject;


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
