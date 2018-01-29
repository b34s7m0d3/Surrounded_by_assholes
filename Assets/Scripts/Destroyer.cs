using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Destroyer : MonoBehaviour
{


    public int winConditionCount = 10;
    public float timeLimitSeconds = 20;

    private int count = 0;
    private GameController gameController;

    void Start()
    {
        //gameControllerObj = GameObject.Find("GameController");
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        bool preparePhase = gameController.IsPreparephase();

        if (!preparePhase)
        {
            // Check Lose condition.
            float timeSincePlayPhaseStart = Time.timeSinceLevelLoad - gameController.GetTimeAtPlayPhaseStart();
            Debug.Log("preparePhase over, checking lose condition.");
            if (count < winConditionCount && timeSincePlayPhaseStart > timeLimitSeconds)
            {
                // Lost
                Debug.Log("Time at lose condition: " + timeSincePlayPhaseStart);
                LoadLevel("Lose");
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            count++;
            Debug.Log("Kill it with fire. Count: " + count + ". Checking Win Condition.");

            Destroy(col.gameObject);

            // Check Win Condition.
            if (count >= winConditionCount)
            {
                // Won
                LoadLevel("Win");
            }
        }
    }

    private void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        //  Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }

}
