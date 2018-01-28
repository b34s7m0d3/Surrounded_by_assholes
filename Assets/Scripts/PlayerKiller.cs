using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour {

    GameObject StuffToKill;
    public float speed = 4.5f;
    public bool move = false;

	// Use this for initialization
	void Start () {

        StuffToKill = GameObject.Find("player");

	}
	
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        move = true;
        Debug.Log("maaan");
    }




    private void Update()
    {
        Vector2 dir = StuffToKill.transform.position - this.transform.localPosition;

        float distThisFrame = speed * Time.deltaTime;
        if (move)
        {
            
                // Move towards node
                transform.Translate(dir.normalized * distThisFrame, Space.World);
        }
        
    }
    


}
