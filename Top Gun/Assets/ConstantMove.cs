using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    public GameObject[] waypoints;
    int curr = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;

    void Update()
    {
        if(Vector3.Distance(waypoints[curr].transform.position, transform.position) < WPradius)
        {
            curr++;
            if (curr >= waypoints.Length)
            {
                curr = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[curr].transform.position, Time.deltaTime * speed);
    }
}
