using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] windows;
    public static UIManager instance;

    private void Start()
    {
        instance = this;
    }

    public void ShowWindow(int windowNumber)
    {
        for(int i = 0; i < windows.Length; i++)
        {
            if (windowNumber == i)
            {
                windows[i].SetActive(true);
            } else
            {
                windows[i].SetActive(false);
            }
        }
    }

}
