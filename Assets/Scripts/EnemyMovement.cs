using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PathFinder pathfinder;

    private List<WayPoint> path;

    private void Start()
    {
        pathfinder = FindObjectOfType<PathFinder>();
        path = pathfinder.GetPath();
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        foreach(WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
