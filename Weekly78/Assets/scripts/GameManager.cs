using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public RowController[] rows = new RowController[6];
    private int[] keys = new int[6];
    private int keyCount;


    private void Start()
    {
        rows[0] = this.transform.Find("Row0").gameObject.GetComponent<RowController>();

        foreach(ShapeChanger shape in rows[0].shapes)
        {
            int rand = Random.Range(0, 4);
            keys[keyCount] = rand;
            Debug.Log(keys[keyCount]);
            keyCount++;

        }

    }

    private void Update()
    {
        if (rows[0].shapes[0].key == keys[0])
        {
            Debug.Log("This shape matches the key!");
        }
        
    }
}
