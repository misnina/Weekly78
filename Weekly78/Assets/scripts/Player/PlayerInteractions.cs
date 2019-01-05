using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public GameObject smallPlayer;
    public GameObject bigPlayer;

    private bool gflower;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("E pressed");
            if (gflower)
            {
                Debug.Log("Run growth");
                Grow();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Trigger");
        if (other.gameObject.tag == "GrowthFlower")
        {
            Debug.Log("GrowthFlower triggered");
            gflower = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "GrowthFlower")
        {
            gflower = false;
        }
    }

    private void Grow()
    {
        Vector3 pos = smallPlayer.transform.position;
        smallPlayer.SetActive(false);
        bigPlayer.transform.position = pos;
        bigPlayer.SetActive(true);

    }


}
