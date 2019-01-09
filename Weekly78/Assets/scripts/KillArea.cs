using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySound("kill");
            Destroy(this.transform.parent.gameObject);
            PlayerController.instance.Jump();
        }
    }
}
