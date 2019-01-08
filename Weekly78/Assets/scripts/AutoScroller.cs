using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroller : MonoBehaviour
{

    public Transform endPoint;
    public Transform player;
    public float speed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(endPoint.position.x, player.position.y, transform.position.z), step);
    }
}
