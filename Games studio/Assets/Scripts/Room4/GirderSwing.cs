using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirderSwing : MonoBehaviour
{

    public float swingTimer;
    public float swingTimerSin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swing();
    }

    void Swing()
    {
        swingTimer += Time.deltaTime * .5f;

        swingTimerSin = Mathf.Sin(swingTimer) * 20;

        this.transform.position = new Vector3(65f+swingTimerSin, 9f, -38f);
    }

    void OnCollisionStay(Collision other) 
    {
        other.gameObject.transform.parent = this.gameObject.transform;
    }

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
