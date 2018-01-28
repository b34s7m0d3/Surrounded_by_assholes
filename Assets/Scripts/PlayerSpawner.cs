using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour
{

    float spawnCD = 0.25f;
    float spawnCDremaining = 5;
    

    [System.Serializable]
    public class WaveComponent
    {
        public GameObject playerPrefab;
        public GameObject parent;
        public int num;
        [System.NonSerialized]
        public int spawned = 0;
    }

    public WaveComponent[] waveComps;

    GameObject controller;



    private void Start()
    {
        
        controller = GameObject.Find("GameController");

       
    }

    void SpawnPlayer(bool didSpawn)
    {
        foreach (WaveComponent wc in waveComps)
        {
            //wc.playerPrefab.transform.parent = gameObject.transform;
            if (!controller.GetComponent<GameController>().preparePhase)
            {
                if (wc.spawned < wc.num)
                {
                    // Spawn it!

                    wc.spawned++;
                    //GameObject spawnling = Instantiate(wc.playerPrefab, this.transform.position, this.transform.rotation) as GameObject;
                    //spawnling.transform.parent = gameObject.transform;
                    Instantiate(wc.playerPrefab, this.transform.position, this.transform.rotation);
                    
                    didSpawn = true;
                    break;
                }
            }

            if (didSpawn == false)
            {
                // Wave must be complete!
                // TODO: Instantiate next wave object!

                if (transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    // That was the last wave -- what do we want to do?
                    // What if instead of DESTROYING wave objects,
                    // we just made them inactive, and then when we run
                    // out of waves, we restart at the first one,
                    // but double all enemy HPs or something?

                    return;

                }

                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnCDremaining -= Time.deltaTime;
        if (spawnCDremaining < 0)
        {
            spawnCDremaining = spawnCD;

            bool didSpawn = false;

            if (!controller.GetComponent<GameController>().preparePhase)
            {
                SpawnPlayer(didSpawn);
            }
           

                // Go through the wave comps until we find something to spawn;

        }
    }
}
