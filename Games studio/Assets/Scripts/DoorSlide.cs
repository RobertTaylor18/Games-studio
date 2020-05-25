using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    public bool activate;
    public float slide;
    // Start is called before the first frame update
    void Start()
    {
        activate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            transform.Translate(Vector3.up * -1 * slide * Time.deltaTime);
            
        }
        if (transform.position.x < 1f)
        {
            transform.position = new Vector3(1f, 7f, 29f);
        }
    }
}
