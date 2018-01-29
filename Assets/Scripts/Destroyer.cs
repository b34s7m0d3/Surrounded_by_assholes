using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Destroyer : MonoBehaviour
{


    public int winConditionCount = 10;
    public float timeLimitSeconds = 20;

    private int count = 0;
    private GameObject gameControllerObj;
    private GameController gameController;

    void Start()
    {
        gameControllerObj = GameObject.Find("GameController");
        gameController = gameControllerObj.GetComponent<GameController>();
    }

    private void Update()
    {
        // TODO: if playphase
        float timeSincePlayPhaseStart = Time.timeSinceLevelLoad - gameController.GetTimeAtPlayPhaseStart();
        // Check Lose condition.
        if (count < winConditionCount && timeSincePlayPhaseStart > timeLimitSeconds)
        {
            // Lost
            Debug.Log("Time at lose condition: " + timeSincePlayPhaseStart);
            LoadLevel("Lose");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        count++;
        Debug.Log("Kill it with fire. Count: " + count);

        Destroy(col.gameObject);

        // Check Win Condition.
        if (count >= winConditionCount)
        {
            // Won
            LoadLevel("Win");
        }
    }

    private void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        //  Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }

}
