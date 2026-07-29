using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] float planeWidth;
    [SerializeField] float planeLenght;
    [SerializeField] float radius;
    [SerializeField] GameObject[] treePrefabs = new GameObject[3];
    [SerializeField] Transform treeParent;
    [SerializeField] float minSpacing = 3.5f;
    [SerializeField] int rejectionSamples = 30;
    readonly List<Vector2> _points = new List<Vector2>();
    void Start()
    {
        GenerateTrees();
    }

    // Update is called once per frame
    void GenerateTrees()
    {
        Random.State previousState = Random.state;
        _points.Clear();
        PossionDiscSample();
        Transform parent = treeParent != null ? treeParent : transform;
        foreach(Vector2 p in _points)
        {
            if(p.magnitude < radius) continue;
            Vector3 worldPos = transform.position + new Vector3(p.x, 0f, p.y);
            GameObject prefab = treePrefabs[Random.Range(0, treePrefabs.Length)];
            if (prefab == null ) continue;
            GameObject tree = Instantiate(prefab, worldPos, Quaternion.identity, parent);
        }
        Random.state = previousState;
    }
    void PossionDiscSample()
    {
        float halfW = planeWidth * 0.5f;
        float halfL = planeLenght * 0.5f;
        float cellSize = minSpacing / Mathf.Sqrt(2f);
        int gridW = Mathf.CeilToInt(planeWidth / cellSize);
        int gridH = Mathf.CeilToInt(planeLenght / cellSize);
        int[,] grid = new int[gridW, gridH];
        for (int x = 0; x < gridW; x++)
        {
            for (int y = 0; y < gridH; y++)
            {
                grid[x, y] = -1;
            }
        }
        List<Vector2> active = new List<Vector2>();
        Vector2 first = new Vector2(Random.Range(-halfW, halfW), Random.Range(-halfL, halfL));
        _points.Add(first);
        active.Add(first);
        SetGrid(grid, first, 0, halfW, halfL, cellSize, gridW, gridH);
        while (active.Count > 0)
        {
            int idx = Random.Range(0, active.Count);
            Vector2 center = active[idx];
            bool found = false;
            for (int i = 0; i < rejectionSamples; i++)
            {
                float angle = Random.Range(0f, Mathf.PI * 2f);
                float radius = Random.Range(minSpacing, minSpacing * 2f);
                Vector2 candidate = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
                if (candidate.x < -halfW || candidate.x > halfW || candidate.y < -halfL || candidate.y > halfL)
                    continue;
                if (IsFarEnough(candidate, grid, halfW, halfL, cellSize, gridW, gridH))
                {
                    _points.Add(candidate);
                    active.Add(candidate);
                    SetGrid(grid, candidate, _points.Count - 1, halfW, halfL, cellSize, gridW, gridH);
                    found = true;
                    break;
                }
            }
            if (!found) active.RemoveAt(idx);
        }
    }
    private bool IsFarEnough(Vector2 candidate, int[,] grid, float halfW, float halfL, float cellSize, int gridW, int gridH)
    {
        int cx = Mathf.FloorToInt((candidate.x + halfW) / cellSize);
        int cy = Mathf.FloorToInt((candidate.y + halfL) / cellSize);
        int searchRadius = 2;
        for (int x = Mathf.Max(0, cx - searchRadius); x <= Mathf.Min(gridW - 1, cx + searchRadius); x++)
        {
            for (int y = Mathf.Max(0, cy - searchRadius); y <= Mathf.Min(gridH - 1, cy + searchRadius); y++)
            {
                int pointIdx = grid[x, y];
                if (pointIdx == -1) continue;
                if (Vector2.Distance(_points[pointIdx], candidate) < minSpacing) return false;
            }
        }
        return true;
    }
    private void SetGrid(int[,] grid, Vector2 point, int index, float halfW, float halfL, float cellSize, int gridW, int gridH)
    {
        int cx = Mathf.FloorToInt((point.x + halfW) / cellSize);
        int cy = Mathf.FloorToInt((point.y + halfL) / cellSize);
        cx = Mathf.Clamp(cx, 0, gridW - 1);
        cy = Mathf.Clamp(cy, 0, gridH - 1);
        grid[cx, cy] = index;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(planeWidth, 0.1f, planeLenght));

        Gizmos.color = Color.cyan;
        DrawGizmoCircle(transform.position, radius);
    }
    private void DrawGizmoCircle(Vector3 center, float radius, int segments = 48)
    {
        float step = Mathf.PI * 2f / segments;
        Vector3 prev = center + new Vector3(radius, 0f, 0f);
        for (int i = 1; i <= segments; i++)
        {
            float a = step * i;
            Vector3 next = center + new Vector3(Mathf.Cos(a) * radius, 0f, Mathf.Sin(a) * radius);
            Gizmos.DrawLine(prev, next);
            prev = next;
        }
    }

}
