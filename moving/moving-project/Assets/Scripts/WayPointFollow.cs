using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollow : MonoBehaviour
{

    public GameObject[] WayPoints;
    int currentWayPoint = 0;

    public float speed = 1.0f;
    float accuracy = 1.0f;
    public float rotationalSpeed = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        WayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (WayPoints.Length == 0) return;

        Vector3 lookAtGoal = new Vector3(WayPoints[currentWayPoint].transform.position.x,
                                         this.transform.position.y,
                                         WayPoints[currentWayPoint].transform.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(direction),
                                                   Time.deltaTime * rotationalSpeed);

        if(direction.magnitude < accuracy)
        {
            currentWayPoint++;
            if(currentWayPoint >= WayPoints.Length)
            {
                currentWayPoint = 0;
            }
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
