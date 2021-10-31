using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private WayPoint startPoint, finishPoint;

    private Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();

    private Queue<WayPoint> queuePoints = new Queue<WayPoint>();

    [SerializeField] private bool isRunning;

    private Vector2Int[] directions = {
        Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left
    };

    private WayPoint searchPoint;

    private void Start()
    {
        isRunning = true;
        LoadBlocks();
        SetColorPoints();
        //ExploreNearPoints();
        PathFind();
    }

    private void PathFind()
    {
        queuePoints.Enqueue(startPoint);

        while (queuePoints.Count > 0 && isRunning == true)
        {
            searchPoint = queuePoints.Dequeue();
            searchPoint.isExplored = true;
            print("Исследовать соседние клетки из " + searchPoint);
            CheckForEndPoint();
            ExploreNearPoints();
        }
        print("Можем?");
    }

    private void CheckForEndPoint()
    {
        if (searchPoint == finishPoint)
        {
            print("Алгоритм нашёл endPoint");
            isRunning = false;
        }
    }

    private void ExploreNearPoints()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int nearPoints = searchPoint.GetGridPos() + direction;
            try
            {
                WayPoint nearPoint = grid[nearPoints];
                AddPointToQueue(nearPoint);
            }
            catch
            {
                //print("Блок" + nearPoints);
            }
            print("Проверено: " + nearPoints);
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
            print("Добавить в очередь: " + nearPoint);
        }
            
        
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();

        foreach (WayPoint wayPoint in waypoints)
        {
            Vector2Int gridPos = wayPoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
                Debug.LogWarning(wayPoint);
            else
                grid.Add(gridPos, wayPoint);   
        }
    }

    private void SetColorPoints()
    {
        startPoint.SetTopColor(Color.red);
        finishPoint.SetTopColor(Color.yellow);
    }
}
