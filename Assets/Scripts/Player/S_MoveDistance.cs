using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MoveDistance : MonoBehaviour
{

    public float radius = 10f;
    public int segments = 20;
    public LineRenderer lineRenderer;


    private void Start()
    {
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
        DrawCircle();
        lineRenderer.enabled = false;
    }

    private void DrawCircle()
    {
        float angle = 0f;
        float angleIncrement = 360f / (float)segments;

        for (int i = 0; i < segments + 1; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i, new Vector3(x, z, 0f));

            angle += angleIncrement;
        }
    }
}

