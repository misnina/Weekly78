using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour
{

    private bool playerTrigger;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerTrigger)
            {
                Destroy(BackgroundMusic.instance.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerTrigger = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerTrigger = false;
        }

    }
}
