using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private WayPoint startPoint, finishPoint;

    private Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();

    private Queue<WayPoint> queuePoints = new Queue<WayPoint>();

    private Vector2Int[] directions = {
        Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left
    };

    private List<WayPoint> path = new List<WayPoint>();

    private WayPoint searchPoint;

    private bool isRunning;

    /*private void Start()
    {
        isRunning = true;
        LoadBlocks();
        SetColorPoints();
        PathFind();
        CreatePath();
    }*/

    public List<WayPoint> GetPath()
    {
        isRunning = true;
        LoadBlocks();
        SetColorPoints();
        PathFind();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(finishPoint);
        WayPoint prevPoints = finishPoint.exploredFrom;
        while (prevPoints != startPoint)
        {
            prevPoints.SetTopColor(Color.cyan);
            path.Add(prevPoints);
            prevPoints = prevPoints.exploredFrom;
        }
        path.Add(startPoint);
        path.Reverse();
    }

    private void PathFind()
    {
        queuePoints.Enqueue(startPoint);

        while (queuePoints.Count > 0 && isRunning == true)
        {
            searchPoint = queuePoints.Dequeue();
            searchPoint.isExplored = true;
            CheckForEndPoint();
            ExploreNearPoints();
        }
    }

    private void CheckForEndPoint()
    {
        if (searchPoint == finishPoint)
        {
            finishPoint.SetTopColor(Color.yellow);
            isRunning = false;
        }
    }

    private void ExploreNearPoints()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int nearPoints = searchPoint.GetGridPos() + direction;

            if (grid.ContainsKey(nearPoints))
            {
                WayPoint nearPoint = grid[nearPoints];
                AddPointToQueue(nearPoint);
            }
        }
    }

    private void AddPointToQueue(WayPoint nearPoint)
    {
        if (nearPoint.isExplored || queuePoints.Contains(nearPoint))
        {
            return;
        }
        else
        {
            nearPoint.SetTopColor(Color.black);
            queuePoints.Enqueue(nearPoint);
            nearPoint.exploredFrom = searchPoint; 
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();

        foreach (WayPoint wayPoint in waypoints)
        {
            Vector2Int gridPos = wayPoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
                Debug.LogWarning("Повтор блока: " + wayPoint);
            else
                grid.Add(gridPos, wayPoint);   
        }
    }

    private void SetColorPoints()
    {
        startPoint.SetTopColor(Color.red);
    }
}
