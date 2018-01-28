using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{

    public GameObject StuffToKill;
    public float speed = 4.5f;
    public bool move = false;

    GameObject controller;
    Collider2D col;

    GameObject playerGO;
    Transform targetPlayer;

    int playerIndex = 0;



    // Use this for initialization
    void Start()
    {

        StuffToKill = GameObject.Find("player");
        controller = GameObject.Find("GameController");

        col = this.GetComponent<BoxCollider2D>();
        col.enabled = false;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        move = true;
        Debug.Log("maaan");
        StuffToKill = collision.gameObject;
    }
    


    private void Update()
    {

        if (!controller.GetComponent<GameController>().preparePhase)
        {
            col.enabled = true;

            /*
            if (targetPlayer == null)
            {
                GetNextPlayerNode();
                if (targetPlayer == null)
                {
                    // end of path
                    // right now no need for this. Might be used later

                    return;

                }
                */

            


                Vector2 dir = StuffToKill.transform.position - this.transform.localPosition;


                float distThisFrame = speed * Time.deltaTime;
                if (move)
                {

                    // Move towards node
                    transform.Translate(dir.normalized * distThisFrame, Space.World);
                    if (StuffToKill.transform.position == null)
                    {
                        return;
                    }
                }
            }
        }
    }
//}
