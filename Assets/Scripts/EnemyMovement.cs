using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   [SerializeField] private List<WayPoint> wayPoints;

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        foreach(WayPoint wayPoint in wayPoints)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
