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
        pointLocation = GameObject.Find("Checkpoint" + checkpoint);

        currentPlayer = GameObject.Find("Char" + charSwap.character);

        if (Input.GetKeyDown("r"))
        {
            currentPlayer.gameObject.transform.position = pointLocation.transform.position + (Vector3.up * 2);
        }
    }

    void OnCollisionEnter(Collision other)
    {
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
