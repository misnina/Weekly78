using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    public static BackgroundMusic instance;

    public AudioClip start;
    private AudioSource audioS;

    private bool started;

    void Start()
    {
        audioS = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
       
    }

    private void Update()
    {
        if (!started)
        {
            audioS.PlayOneShot(start);
            started = true;
            Invoke("PlayLoop", 2.2f);
        }
        
    }

    private void PlayLoop()
    {
        audioS.Play();
    }
}
