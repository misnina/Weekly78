using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorSelect : MonoBehaviour
{
    private Vector2 cursorPos;
    private bool triggeredOnce;
    public Transform startPos;
    public Transform endPos;

    private bool playTrigger;
    private bool controlsTrigger;
    private bool creditsTrigger;
    private bool backTrigger;

    public string levelToLoad;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(playTrigger)
            {
                SceneManager.LoadScene(levelToLoad);
                //Replace for level 1
            }
            else if (controlsTrigger)
            {
                UIManager.instance.ShowWindow(1);
            } else if (creditsTrigger)
            {
                UIManager.instance.ShowWindow(2);

            } else if (backTrigger)
            {
                UIManager.instance.ShowWindow(0);
            }
        }

        if (!triggeredOnce)
        {
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                transform.Translate(new Vector2(0f, 1f));
                triggeredOnce = true;
                Invoke("ResetTrigger", 0.25f);
            }
            else if (Input.GetAxisRaw("Vertical") == -1)
            {
                transform.Translate(new Vector2(0f, -1f));
                triggeredOnce = true;
                Invoke("ResetTrigger", 0.25f);
            }
        }
    }

    private void ResetTrigger()
    {
        triggeredOnce = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "BoundsDown")
        {
            Debug.Log("Collided");
            transform.position = startPos.transform.position;
        }
        if (other.gameObject.name == "BoundsUp")
        {
            transform.position = endPos.transform.position;
        }

        //Buttons
        if(other.gameObject.name == "Play")
        {
            playTrigger = true;
        }
        if(other.gameObject.name == "Controls")
        {
            controlsTrigger = true;
        }
        if(other.gameObject.name == "Credits")
        {
            creditsTrigger = true;
        }

        if (other.gameObject.name == "Back")
        {
            backTrigger = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Play")
        {
            playTrigger = false;
        }

        if (other.gameObject.name == "Controls")
        {
            controlsTrigger = false;
        }

        if (other.gameObject.name == "Credits")
        {
            creditsTrigger = false;
        }

        if (other.gameObject.name == "Back")
        {
            backTrigger = false;
        }
    }


}
