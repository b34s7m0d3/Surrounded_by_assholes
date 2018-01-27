﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour {

    public bool preparePhase = true;

    public Button button;

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
        }
        else
        {
            preparePhase = true;
        }
    }

    // Update is called once per frame
    void Update () {
	    if (preparePhase)
        {
            //we can instantiate flags for the users
        }
        else
        {
            // send in the troops
        }
	}
}