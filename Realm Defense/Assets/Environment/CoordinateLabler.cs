using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]

public class CoordinateLabler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.blue;
    [SerializeField] int unityGridSize = 10;

    TextMeshPro lable;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        lable = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();  
    }

    private void Start()
    {
        lable.enabled = false;
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLableColor();
        ToggleLables();
        
    }

    void ToggleLables()
    {
        if (Input.GetKeyDown(KeyCode.C))
            lable.enabled = !lable.IsActive();
    }

    private void SetLableColor()
    {
        if (waypoint.IsPlaceable)
            lable.color = defaultColor;
        else
            lable.color = blockedColor;
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/unityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/unityGridSize);
        lable.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
