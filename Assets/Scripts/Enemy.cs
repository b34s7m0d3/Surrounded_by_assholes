using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float fuckUpProbability;
    public float fuckUpRadius;
    public float maxDisplacement;

    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D fuckUpArea;
    private bool playerDetected;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        fuckUpArea = GetComponent<CircleCollider2D>();
        fuckUpArea.radius = fuckUpRadius;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
        // Wait for time influenced by probability.
        yield return new WaitForSeconds(Random.Range(0f, fuckUpProbability));

        // Get distance and fuck up transmission based on it.
        float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        FuckUpPosition(distanceToPlayer);

    }

    void FuckUpPosition(float distance)
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 displacement = new Vector2(maxDisplacement / distance, maxDisplacement / distance);

        // Displace player.
        playerPosition = playerPosition + displacement;
        Debug.Log("Player position fucked up.");

    }
}
