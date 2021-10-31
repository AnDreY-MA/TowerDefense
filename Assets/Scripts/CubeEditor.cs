using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{
    //[SerializeField] private int gridSize = 10;

    private int gridSize;

    private TextMesh label;
    
    private WayPoint wayPoint;

    private void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
        label = GetComponentInChildren<TextMesh>();
        gridSize = wayPoint.GetGridSize();
    }

    private void Update()
    {
        SnapToGrid();

        LabelUpdate();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(wayPoint.GetGridPos().x * gridSize, 0f, wayPoint.GetGridPos().y * gridSize);
    }

    private void LabelUpdate()
    {
        string labelName = transform.position.x / gridSize + ", " + transform.position.z / gridSize;
        label.text = labelName;
        gameObject.name = labelName;
    }
}
