using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour
{

    public ShapeChanger[] shapes = new ShapeChanger[5];
    public int[] keys = new int [5];
    public bool[] positions = new bool[5];
    private int keyCount;

    
    private void Start()
    {
        shapes[0] = (this.transform.Find("ShowHide").gameObject.transform.Find("Shape0").GetComponent<ShapeChanger>());
        shapes[1] = (this.transform.Find("ShowHide").gameObject.transform.Find("Shape1").GetComponent<ShapeChanger>());
        shapes[2] = (this.transform.Find("ShowHide").gameObject.transform.Find("Shape2").GetComponent<ShapeChanger>());
        shapes[3] = (this.transform.Find("ShowHide").gameObject.transform.Find("Shape3").GetComponent<ShapeChanger>());
        shapes[4] = (this.transform.Find("ShowHide").gameObject.transform.Find("Shape4").GetComponent<ShapeChanger>());
        shapes[5] = (this.transform.Find("ShowHide").gameObject.transform.Find("Shape5").GetComponent<ShapeChanger>());
    }

    private void Update()
    {
        foreach (ShapeChanger shape in shapes)
        {
            keys[keyCount] = shape.key;
            if (keyCount == 4)
            {
                keyCount = 0;
            }
            else
            {
                keyCount++;
            }
              
           
        }
    }


}
