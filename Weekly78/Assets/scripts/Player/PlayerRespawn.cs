using System.Collections;
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
            AudioManager.instance.PlaySound("death");
            PlayerController.instance.canMove = false;
            PlayerController.instance.rb.velocity = Vector2.zero;
            //PlayerController.instance.anim.SetTrigger("death");
            StartCoroutine("Respawn");
            died = false;
        }
    }

    IEnumerator Respawn()
    {
        Debug.Log("Player has died");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerController.instance.canMove = true;

    }
}
