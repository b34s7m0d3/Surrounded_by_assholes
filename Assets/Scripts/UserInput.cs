using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;


public class UserInput : MonoBehaviour {


    public Button yourButton;
    public ArrayList inputKeys = new ArrayList();
    public float chance = 0.9f;

	// Use this for initialization
	void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
    }
   

    void TaskOnClick()
    {
        // just to test if we have all the instructions from the player
        for (int i = 0; i < inputKeys.Count; i++)
        {
            if (Random.value < chance) {
                Debug.Log(inputKeys[i]);
                chance -= 0.1f;
            } else chance -= 0.1f;
        }

        inputKeys = new ArrayList();
        chance = Random.value;

    }

    // Update is called once per frame
    void Update () {


        // can be extended with diverse set of instructions from the player

            if (Input.GetKey("down"))
            {
                inputKeys.Add("down");
            }
            if (Input.GetKey("right"))
            {
                inputKeys.Add("right");
            }
            if (Input.GetKey("left"))
            {
                inputKeys.Add("left");
            }
            if (Input.GetKey("up"))
            {
                inputKeys.Add("up");
            }
        

        
	}
}
