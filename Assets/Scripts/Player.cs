using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameObject pathGO;

    Transform targetPathNode;
    int pathNodeIndex = 0;

    public float speed = 5.0f;

	// Use this for initialization
	void Start () {
        pathGO = GameObject.Find("Path");
	}
	
    void GetNextPathNode()
    {
        targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
        pathNodeIndex++;
    }

	// Update is called once per frame
	void Update () {
        if (targetPathNode == null)
        {
            GetNextPathNode();
            if (targetPathNode == null)
            {
                // end of path
                ReachGoal();
            }
        }

        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distThisFrame)
        {
            // We reached the node
            targetPathNode = null;

        }
        else
        {
            // Move towards node
            transform.Translate(dir.normalized * distThisFrame);
        }

	}

    void ReachGoal()
    {
        Destroy(this);
    }

}
