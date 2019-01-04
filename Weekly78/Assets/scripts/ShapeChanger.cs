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

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (isSquare)
        {
            sp.sprite = triangle;
            isTriangle = true;
            isSquare = false;
        }
        else if (isTriangle)
        {
            sp.sprite = circle;
            isCircle = true;
            isTriangle = false;
        }
        else if (isCircle)
        {
            sp.sprite = diamond;
            isDiamond = true;
            isCircle = false;
        }
        else if (isDiamond)
        {
            sp.sprite = square;
            isSquare = true;
            isDiamond = false;
        }
    }
}
