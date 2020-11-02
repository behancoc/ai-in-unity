using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject wpManager;
    GameObject[] wps;
    UnityEngine.AI.NavMeshAgent agent;
    

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void GoToHeli()
    {
        agent.SetDestination(wps[16].transform.position);
        //graph.AStar(currentNode, wps[14]);
        //currentWP = 0;   
    }

    public void GoToRuin()
    {
        agent.SetDestination(wps[15].transform.position);
        //graph.AStar(currentNode, wps[6]);
        //currentWP = 0;
    }

    public void GoToTanks()
    {
        //graph.AStar(currentNode, wps[18]);
        //currentWP = 0;
    }


    void LateUpdate()
    {
        
    }
}
