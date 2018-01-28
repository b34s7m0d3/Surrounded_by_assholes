using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minWaitBeforeFuckUp = 0.1f;
    public float maxWaitBeforeFuckUp = 1f;
    public float fuckUpRadius = 3f;
    public float maxDisplacement = 10f;

    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D fuckUpArea;
    private bool playerDetected;
    GameObject controller;
    bool canDo;

    // Use this for initialization
    void Start()
    {
       

        spriteRenderer = GetComponent<SpriteRenderer>();

        controller = GameObject.Find("GameController");
        canDo = controller.GetComponent<GameController>().preparePhase;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canDo)
        {
            CreateCollider();
        }
    }

    void CreateCollider()
    {
        fuckUpArea = GetComponent<CircleCollider2D>();
        fuckUpArea.radius = fuckUpRadius;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            player = otherCollider.gameObject;
            //playerDetected = true;
            StartCoroutine(FuckUpTransmission());

            spriteRenderer.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            //playerDetected = false;
            spriteRenderer.color = Color.blue;
        }
    }

    IEnumerator FuckUpTransmission()
    {
        // Wait for randomized time range.
        yield return new WaitForSeconds(Random.Range(minWaitBeforeFuckUp, maxWaitBeforeFuckUp));

        // Get player position.
        Vector2 playerPosition = player.transform.position;

        // Get distance to player.
        float distanceToPlayer = Vector2.Distance(playerPosition, transform.position);

        // Calculate displacement vector based on distance.
        Vector2 displacement = new Vector2(maxDisplacement / distanceToPlayer, maxDisplacement / distanceToPlayer);

        // Calculate displaced player position.
        playerPosition = playerPosition + displacement;
        // IMPORTANT: APPLY displaced player position. (UNITY QUIRK! Need to explicitly apply to the player's transform.)
        player.transform.position = playerPosition;
        Debug.Log(player.name + " displaced by: " + displacement);
    }
}
