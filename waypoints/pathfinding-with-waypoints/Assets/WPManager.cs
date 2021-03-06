﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction { UNI, BI};
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}


public class WPManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph = new Graph();

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Start() method called!");

        foreach(GameObject wp in waypoints)
        {
            Debug.Log("Adding nodes to graph");
            graph.AddNode(wp);
        }

        foreach(Link link in links)
        {
            Debug.Log("Adding edges to graph");
            graph.AddEdge(link.node1, link.node2);
            if(link.dir == Link.direction.BI)
            {
                graph.AddEdge(link.node2, link.node1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        graph.debugDraw();
    }
}
