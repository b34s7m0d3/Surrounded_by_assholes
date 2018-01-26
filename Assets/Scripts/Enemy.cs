using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fuckUpProbability;
    public float fuckUpRadius;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is nearby and fuck up transmission, if so.
        if (GetDistanceToPlayer() <= fuckUpRadius)
        {
            FuckUpTransmission();
        }

    }

    float GetDistanceToPlayer()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log("Distance to player: " + distance);
        return distance;
    }

    void FuckUpTransmission()
    {
        // Take distance to player and individual fuckUpProbability into account.
    }
}
