using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirderSwing : MonoBehaviour
{
    public float swingTimer;
    public float swingTimerSin;
 
    // We run the Swing function every frame
    void Update()
    {
        Swing();
    }

    //This moves the given platform back and forth at a constant rate
    void Swing()
    {
        swingTimer += Time.deltaTime * .5f;

        swingTimerSin = Mathf.Sin(swingTimer) * 20;

        this.transform.position = new Vector3(65f+swingTimerSin, 9f, -38f);
    }

    // When an object is on the platform, it becomes a child of the object so that the player moves with the moving platform
    void OnCollisionStay(Collision other) 
    {
        other.gameObject.transform.parent = this.gameObject.transform;
    }

    // Once an object is no longer on the platform it gets put back in the hierarchy where it was before
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Crate"))
        {
            other.gameObject.transform.parent = GameObject.Find("Props").transform;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = GameObject.Find("Char2").transform;
        }
    }
}
