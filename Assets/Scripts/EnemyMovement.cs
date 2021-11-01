using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PathFinder pathfinder;

    private List<WayPoint> path;

    Vector3 yn;

    private void Start()
    {
        pathfinder = FindObjectOfType<PathFinder>();
        path = pathfinder.GetPath();
        StartCoroutine(Move());
        yn = transform.position;
        yn.y = 8.5f;
    }

    private IEnumerator Move()
    {
        foreach(WayPoint wayPoint in path)
        {
            transform.LookAt(wayPoint.transform); 
            transform.position = wayPoint.transform.position + yn;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
