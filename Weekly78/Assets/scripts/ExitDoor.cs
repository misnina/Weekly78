using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public string sceneToLoad;
    private bool playerTrigger;


    private void Update()
    {
        if(playerTrigger && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerTrigger = true;
        }
    }
}
