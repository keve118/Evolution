using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public static Transform[] waypoints;

    private void Awake()
    {
        //gets the waypoints and places them in an array
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
           waypoints[i] = transform.GetChild(i);
        }
    }

}
