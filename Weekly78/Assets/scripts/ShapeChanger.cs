using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeChanger : MonoBehaviour
{
    public Sprite square;
    public Sprite triangle;
    public Sprite circle;
    public Sprite diamond;

    private SpriteRenderer sp;

    private bool isSquare = true;
    private bool isTriangle;
    private bool isCircle;
    private bool isDiamond;

    public int key;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (isSquare)
        {
            key = 0;
        }
        else if (isTriangle)
        {
            key = 1;
        }
        else if (isCircle)
        {
            key = 2;
        }
        else if (isDiamond)
        {
            key = 3;
        }

    }

    private void OnMouseUp()
    {
        if (isSquare)
        {
            sp.sprite = triangle;
            isTriangle = true;
            isSquare = false;
            key = 0;
        }
        else if (isTriangle)
        {
            sp.sprite = circle;
            isCircle = true;
            isTriangle = false;
            key = 1;
        }
        else if (isCircle)
        {
            sp.sprite = diamond;
            isDiamond = true;
            isCircle = false;
            key = 2;
        }
        else if (isDiamond)
        {
            sp.sprite = square;
            isSquare = true;
            isDiamond = false;
            key = 3;
        }
    }
}
