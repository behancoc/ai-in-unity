using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class WaypointFollow : MonoBehaviour
{

    public GameObject[] waypoints;
    int currentWayPoint = 0;

    float speed = 3.0f;
    float accuracy = 1.0f;
    float rotationalSpeed = 1.4f;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (waypoints.Length == 0)
        {
            Debug.LogError("No WaypointCircuit component found!");
            return;
        }

        Vector3 lookAtGoal = new Vector3(waypoints[currentWayPoint].transform.position.x,
                                         this.transform.position.y,
                                         waypoints[currentWayPoint].transform.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(direction),
                                                   Time.deltaTime * rotationalSpeed);

        if(direction.magnitude < accuracy)
        {
            currentWayPoint++;
            if(currentWayPoint >= waypoints.Length)
            {
                currentWayPoint = 0;
            }
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
