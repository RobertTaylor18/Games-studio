using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public KillZone killScript;
    public KillZone ceilingKillScript;
    public BoxCollider BoxCol;

    // Start is called before the first frame update
    void Start()
    {
        killScript = GameObject.Find("KillZone").GetComponent<KillZone>();
        ceilingKillScript = GameObject.Find("LoweringCeiling").GetComponent<KillZone>();
        BoxCol = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            killScript.checkpoint++;
            ceilingKillScript.checkpoint++;
            BoxCol.enabled = false;
        }
        
    }
}
