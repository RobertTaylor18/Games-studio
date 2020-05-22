using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateLift : MonoBehaviour
{
    public Transform theDest;
    public CharSwap swapScript;
    public Rigidbody rBody;
    public Renderer crateRenderer;
 

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        swapScript = GameObject.Find("Player").GetComponent<CharSwap>();

        crateRenderer = this.GetComponent<Renderer>();
    }



    void OnMouseDown()
    {
        if (swapScript.character == 1) {
            rBody.useGravity = false;
            rBody.constraints = RigidbodyConstraints.FreezeAll;
            this.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("Destination").transform;
            Color tempColor = crateRenderer.material.color;
            tempColor.a = 0.25f;
            crateRenderer.material.color = tempColor;
        }
    }

    void OnMouseUp()
    {
        this.transform.parent = GameObject.Find("Props").transform;
        rBody.useGravity = true;
        rBody.constraints = RigidbodyConstraints.None;
        Color tempColor = crateRenderer.material.color;
        tempColor.a = 1;
        crateRenderer.material.color = tempColor;
    }
}
