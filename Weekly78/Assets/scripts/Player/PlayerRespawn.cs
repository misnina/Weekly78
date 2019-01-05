﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public bool died;

    public static PlayerRespawn instance;

    void Start()
    {
        instance = this;  
    }

    
    void Update()
    {
        if (died)
        {
            PlayerController.instance.canMove = false;
            StartCoroutine("Respawn");
            died = false;
        }
    }

    IEnumerator Respawn()
    {
        Debug.Log("Player has died");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerController.instance.canMove = true;

    }
}