using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{

    public bool preparePhase = true;
    public Button button;

    private float timeAtPlayPhaseStart;


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

            // Log PlayPhase start time.
            timeAtPlayPhaseStart = Time.timeSinceLevelLoad;
            Debug.Log("timeAtPlayPhaseStart captured as: " + timeAtPlayPhaseStart);
        }
        else
        {
            preparePhase = true;
        }
    }

    public float GetTimeAtPlayPhaseStart()
    {
        return timeAtPlayPhaseStart;
    }

    public bool IsPreparephase()
    {
        return preparePhase;
    }

}


