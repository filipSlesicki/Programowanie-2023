using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{
    [Tooltip("Line prefab must have 2 points and be set to world space")]
    [SerializeField] private LineRenderer linePrefab;
    [SerializeField] private float lineLifespan = 0.1f;
   private Vector3[] linePositions = new Vector3[2];
    public void DrawLineToPoint(Vector3 point)
    {
        LineRenderer line = Instantiate(linePrefab, transform.position, transform.rotation);
        linePositions[0] = transform.position;
        linePositions[1] = point;
        line.SetPositions(linePositions);
        Destroy(line, lineLifespan);
    }

    public void DrawLineToHitPoint(RaycastHit hit)
    {
        DrawLineToPoint(hit.point);
    }
}
