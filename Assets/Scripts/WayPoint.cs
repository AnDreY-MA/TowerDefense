using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public WayPoint exploredFrom;

    public bool isExplored = false;

    private const int gridSize = 10;

    //private Vector2Int gridPos;

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
             Mathf.RoundToInt(transform.position.x / gridSize),
             Mathf.RoundToInt(transform.position.z / gridSize));
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)this;
    }
}
