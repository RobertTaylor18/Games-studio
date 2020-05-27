using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollAnim : MonoBehaviour
{
    public float scroll;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, -1 * scroll * Time.deltaTime, 0f);
        if (transform.position.y < 0) 
        {
            transform.position = new Vector3(15f, 6.3f, 42f);
        }
    }
}
