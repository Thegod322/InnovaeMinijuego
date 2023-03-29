using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class S_PathVisuals : MonoBehaviour
{
    public NavMeshAgent agent;
    public LineRenderer line;
    private bool isPathVisible = false;
    [SerializeField]private Vector3[] pathPoints = new Vector3[0];

    private void Update()
    {/*
        if (agent.hasPath)
        {
            if (!isPathVisible)
            {
                line.enabled = true;
                isPathVisible = true;
            }

            if (pathPoints.Length != agent.path.corners.Length)
            {
                pathPoints = agent.path.corners;
                line.positionCount = pathPoints.Length;
            }

            for (int i = 0; i < pathPoints.Length; i++)
            {
                line.SetPosition(i, pathPoints[i]);
            }
        }
        else if (isPathVisible)
        {
            line.enabled = false;
            isPathVisible = false;
        }*/
    }

    public void UpdateVisuals()
    {
        if (agent.hasPath)
        {
           

            pathPoints = agent.path.corners;
            line.positionCount = pathPoints.Length;


            for (int i = 0; i < pathPoints.Length; i++)
            {
                line.SetPosition(i, pathPoints[i]);
            }
        }
        else if (isPathVisible)
        {
            line.enabled = false;
            isPathVisible = false;
        }
    }
}
