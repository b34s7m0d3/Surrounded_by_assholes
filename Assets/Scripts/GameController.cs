using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{

    public bool preparePhase = true;
    public Button button;

    private float timeAtStart;


    private void Start()
    {
        Button btn = button.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        if (preparePhase)
        {
            preparePhase = false;

            // Log game start time.
            timeAtStart = Time.time;
        }
        else
        {
            preparePhase = true;
        }
    }

    public float GetTimeAtStart()
    {
        Debug.Log("timeAtStart was captured as: " + timeAtStart);
        return timeAtStart;
    }

}


