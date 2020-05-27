using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    public int checkpoint;
    public GameObject pointLocation;
    public GameObject currentPlayer;
    public CharSwap charSwap;
    public AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = 0;
        charSwap = GameObject.Find("Player").GetComponent<CharSwap>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sets respawn to last checkpoint
        pointLocation = GameObject.Find("Checkpoint" + checkpoint);

        currentPlayer = GameObject.Find("Char" + charSwap.character);

        //Manual respawn
        if (Input.GetKeyDown("r"))
        {
            currentPlayer.gameObject.transform.position = pointLocation.transform.position + (Vector3.up * 2);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //If player collides then respawn if anything else collides play scream and destroy it
        if (other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.transform.position = pointLocation.transform.position;
        }
        else
        {
            audioSrc.Play();
            Destroy(other.gameObject);
        }
    }
}
