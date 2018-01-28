using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    GameObject pathGO;
    GameObject pathEND;

    Transform targetPathNode;

    int pathNodeIndex = 0;

    public float speed = 5.0f;

    GameObject controller;

    // Use this for initialization
    void Start()
    {
        pathGO = GameObject.Find("Path");

        controller = GameObject.Find("GameController");
        pathEND = GameObject.Find("EndPoint");
	
	
    }


    void GetNextPathNode()
    {
        if (pathNodeIndex < pathGO.transform.childCount)
        {
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else
        {
            
            targetPathNode = pathEND.transform;
            // might need to optimize this
            /*
            Vector2 comparison = this.transform.position;
            Vector2 end = pathEND.transform.position;
            if (comparison == end + accuracy || comparison == end -accuracy)
            {
                targetPathNode = null;
            }
            */
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!controller.GetComponent<GameController>().preparePhase)
        {
            // follow phase start
            //Debug.Log("not preparing");

            if (targetPathNode == null)
            {
                GetNextPathNode();
                if (targetPathNode == null)
                {
                    // end of path
                    // right now no need for this. Might be used later
                    ReachGoal();
                    return;
                
            }
        }


            Vector2 dir = targetPathNode.position - this.transform.localPosition;

            float distThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distThisFrame)
            {
                // We reached the node
                targetPathNode = null;
            }
            else
            {
                // Move towards node
                transform.Translate(dir.normalized * distThisFrame, Space.World);
            }

        }
    }

    void ReachGoal()
    {
        Destroy(this.gameObject, 0.1f);
    }

}
