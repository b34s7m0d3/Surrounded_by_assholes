using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minFuckUpProbability, maxFuckUpProbability;
    public float fuckUpRadius;
    public float maxDisplacement;
    

    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D fuckUpArea;
    private bool playerDetected;

    GameObject controller;

    bool canDo;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GameObject.Find("GameController");
        canDo = controller.GetComponent<GameController>().preparePhase;

        

        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!canDo)
        {
            CreateCollider();
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            playerDetected = true;
            spriteRenderer.color = Color.red;
            StartCoroutine(FuckUpTransmission());
 
            Debug.Log("enter");
        }
    }

    void CreateCollider()
    {
        fuckUpArea = GetComponent<CircleCollider2D>();
        fuckUpArea.radius = fuckUpRadius;
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            playerDetected = false;
            spriteRenderer.color = Color.blue;
        }
    }

    IEnumerator FuckUpTransmission()
    {
        // Wait for randomized time range.
        yield return new WaitForSeconds(Random.Range(minFuckUpProbability, maxFuckUpProbability));

        // Get distance and fuck up transmission based on it.
        float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        FuckUpPosition(distanceToPlayer);

    }

    void FuckUpPosition(float distance)
    {
        Vector2 playerPosition = player.transform.position;
        Debug.Log("Player position BEFORE displacement: " + playerPosition);

        Vector2 displacement = new Vector2(maxDisplacement / distance, maxDisplacement / distance);
        Debug.Log("displacement Vector: " + displacement);

        // Displace player.
        playerPosition = playerPosition + displacement;
        Debug.Log("Player position AFTER displacement: " + playerPosition);

    }
}
