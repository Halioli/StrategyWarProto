using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathCreator : MonoBehaviour
{
    private static float MIN_DISTANCE = 1f;

    private PathMover pathMover;
    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();

    private void Awake()
    {
        pathMover = GetComponentInParent<PathMover>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // Click
        if (Input.GetButtonDown("Fire1"))
        {
            ClearLine();
        }


        // Held
        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (DistanceToLastPoint(hitInfo.point) > MIN_DISTANCE)
                {
                    points.Add(hitInfo.point);

                    lineRenderer.positionCount = points.Count;
                    lineRenderer.SetPositions(points.ToArray());
                }
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            pathMover.SetPoints(points);
        }
    }

    private float DistanceToLastPoint(Vector3 point)
    {
        if (!points.Any())
            return Mathf.Infinity;

        return Vector3.Distance(points[points.Count - 1], point);
    }

    public void ClearLine()
    {
        points.Clear();
        lineRenderer.positionCount = 0;
    }
}
