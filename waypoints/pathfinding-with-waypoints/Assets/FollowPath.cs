using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    float speed = 5.0f;
    float accuracy = 1.0f;
    float rotationalSpeed = 2.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph graph;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        graph = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];
    }

    public void GoToHeli()
    {
        graph.AStar(currentNode, wps[14]);
        currentWP = 0;
    }

    public void GoToRuin()
    {
        graph.AStar(currentNode, wps[6]);
        currentWP = 0;
    }
    

    private void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWP == graph.getPathLength())
        {
            return;
        }

        if(Vector3.Distance(graph.getPathPoint(currentWP).transform.position, transform.position) < accuracy)
        {
            currentWP ++;
        }

        if(currentWP < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);

            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationalSpeed);
        }
    }
}
