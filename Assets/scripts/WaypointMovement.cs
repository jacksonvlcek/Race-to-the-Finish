using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moves an object between empty waypoint objects
public class WaypointMovement : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    int currentWaypointIndex = 0;
    [SerializeField] float waypointSpeed = 1f;

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

        }
        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, waypointSpeed * Time.deltaTime);
    }
}
