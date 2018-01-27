using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathCreator : MonoBehaviour {

    public GameObject prefab;
    public GameObject parent;

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray))
        {
            GameObject childObject = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            childObject.transform.parent = parent.transform;
        }
    }
}
