using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public KillZone killScript;
    public BoxCollider BoxCol;

    // Start is called before the first frame update
    void Start()
    {
        killScript = GameObject.Find("KillZone").GetComponent<KillZone>();
        BoxCol = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        killScript.checkpoint++;
        BoxCol.enabled = false;
        
    }
}
