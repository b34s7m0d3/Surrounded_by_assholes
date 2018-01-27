﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathCreator : MonoBehaviour
{

    public GameObject prefab;
    public GameObject parent;

    void OnMouseDown()
    {
        // Calculate rounded position from clicked position.
        Vector2 rawPosistion = CalculateWorldPointOfClick();
        Vector2 snappedPosition = SnapToWorldGrid(rawPosistion);

        SpawnWaypoint(prefab, snappedPosition);
    }

    Vector2 CalculateWorldPointOfClick()
    {
        // Get camera component of first found camera object.
        Camera camera = FindObjectOfType<Camera>().GetComponent<Camera>();

        // Calculate world units from mouse position (pixels).
        return camera.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector2 SnapToWorldGrid(Vector2 rawWorldPosition)
    {
        int roundedX, roundedY;
        roundedX = Mathf.RoundToInt(rawWorldPosition.x);
        roundedY = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(roundedX, roundedY);
    }

    void SpawnWaypoint(GameObject obj, Vector2 position)
    {
        GameObject newWaypoint = Instantiate(obj, position, Quaternion.identity) as GameObject;
        newWaypoint.transform.parent = parent.transform;
    }

}