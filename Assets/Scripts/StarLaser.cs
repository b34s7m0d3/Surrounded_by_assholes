using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLaser : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("Lazeeer");
        this.GetComponentInParent<PlayerKiller>().move = false;
    }
}
