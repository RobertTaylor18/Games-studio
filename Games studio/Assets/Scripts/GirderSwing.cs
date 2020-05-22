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
        swingTimer += Time.deltaTime;

        swingTimerSin = Mathf.Sin(swingTimer) * 30;

        this.transform.position = new Vector3(60f+swingTimerSin, 9f, -38f);
    }
}
