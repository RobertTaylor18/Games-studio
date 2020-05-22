using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCeiling : MonoBehaviour
{
    [SerializeField] private Animator myAnimationContoller;

    public bool activated = false;
    public float movingSpeed;

    public Rigidbody ceiling;
    public Rigidbody door;
    public Transform leverHandel;
    public GameObject MSMR;
    public GameObject temp;

    public CeilingCollider ceilingCollider;

    public SelectionManager selectionManager;

    void Start()
    {
        selectionManager = MSMR.GetComponent<SelectionManager>();
        ceilingCollider = ceiling.GetComponent<CeilingCollider>();


    }
    // Update is called once per frame
    void Update()
    {
        if (selectionManager._selection == leverHandel)
        {
            if (Input.GetKeyDown("e"))
            {
                if (!activated)
                {
                    myAnimationContoller.SetBool("leverActive", true);
                    activated = true;
                }
                else if (activated)
                {
                    myAnimationContoller.SetBool("leverActive", false);
                    activated = false;
                }
            }
        }

        if (activated)
        {
            
            ceiling.velocity = new Vector3(0, -0.5f, 0);
            door.velocity = new Vector3(4, 0, 0);

        }
        else if (!activated)
        {
            myAnimationContoller.SetBool("leverActive", false);
            ceiling.transform.localPosition = new Vector3(95.56999f,48.9802f, -17.98616f);
            door.transform.localPosition = new Vector3(125.64f, 7.78f, 14.87f);
        }

        if (door.transform.localPosition.x > 132)
        {
            door.velocity = Vector3.zero;
        }

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
        else
        {
            ceiling.velocity = Vector3.zero;
        }
    }

}
