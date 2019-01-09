using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public GameObject smallPlayer;
    public GameObject bigPlayer;
    public GameObject largePlayer;

    private bool gflower;
    private bool sflower;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (gflower)
            {
                Grow();
            }

            if (sflower)
            {
                Shrink();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GrowthFlower")
        {
            gflower = true;
        }

        if(other.gameObject.tag == "ShrinkFlower")
        {
            sflower = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "GrowthFlower")
        {
            gflower = false;
        }

        if (other.gameObject.tag == "ShrinkFlower")
        {
            sflower = false;
        }
    }

    private void Grow()
    {
        if(smallPlayer.activeInHierarchy)
        {
            AudioManager.instance.PlaySound("flower");
            Vector3 pos = smallPlayer.transform.position;
            smallPlayer.SetActive(false);
            bigPlayer.transform.position = pos;
            bigPlayer.SetActive(true);
            gflower = false;
        } else if (bigPlayer.activeInHierarchy)
        {
            AudioManager.instance.PlaySound("flower");
            Vector3 pos = bigPlayer.transform.position;
            bigPlayer.SetActive(false);
            largePlayer.transform.position = pos;
            largePlayer.SetActive(true);
            gflower = false;
        } else
        {
            //Do Nothing
        }

    }

    private void Shrink()
    {
        if (bigPlayer.activeInHierarchy)
        {
            AudioManager.instance.PlaySound("flower");
            Vector3 pos = bigPlayer.transform.position;
            bigPlayer.SetActive(false);
            smallPlayer.transform.position = pos;
            smallPlayer.SetActive(true);
            sflower = false;
        } else if (largePlayer.activeInHierarchy)
        {
            AudioManager.instance.PlaySound("flower");
            Vector3 pos =largePlayer.transform.position;
            largePlayer.SetActive(false);
            bigPlayer.transform.position = pos;
            bigPlayer.SetActive(true);
            sflower = false;
        } else
        {
            //Do Nothing
        }
     
    }


}
