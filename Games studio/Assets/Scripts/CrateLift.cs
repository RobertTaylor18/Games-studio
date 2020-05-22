using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateLift : MonoBehaviour
{
    public Transform theDest;
    public CharSwap swapScript;
    public Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        swapScript = GameObject.Find("Player").GetComponent<CharSwap>();
    }

    void OnMouseDown()
    {
        if (swapScript.character == 1) {
            rBody.useGravity = false;
            rBody.constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("Destination").transform;
        }
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        rBody.useGravity = true;
        rBody.constraints = RigidbodyConstraints.None;
    }
}
