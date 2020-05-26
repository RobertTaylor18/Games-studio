using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public AudioSource audioSrc;
    public int chars = 0;
    public bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("FPSController");    
        player2 = GameObject.Find("FPSController (1)");
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (chars > 2 && isPlaying == false)
        {
            audioSrc.Play();
            StartCoroutine("endTimer");
            isPlaying = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player1)
        {
            chars++;
            
        }
        else if (other.gameObject == player2)
        {
            chars++;
        }

       /* if (other.gameObject == player1 && other.gameObject == player2)
        {
            audioSrc.Play();
            StartCoroutine("endTimer");
        }*/

        

    }

    public IEnumerator endTimer()
    {

        yield return new WaitForSeconds(6f);//Uses a timer outside of update so it isn't tied to fps
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}
