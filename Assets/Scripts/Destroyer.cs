using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {


    public int count = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log("Kill it with fire");
        count++;
        Destroy(col.gameObject);

    }

}
