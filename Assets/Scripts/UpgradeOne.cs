using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeOne : MonoBehaviour
{

    // need access to sheep prefab
    // need variable for time last sheep
    // need variable for time of next sheep

    // need bool to check if script is enabled or not

    [SerializeField] private GameObject sheepPrefab;
    private float spawnTime = 1f;
    private float lastSpawn = 0f;
    private bool onField = false;

    // instantiate the sheepPrefab every 1 second
    // script needs to check if 1 second has passed
    // if the time of 1 second hasn't passed - do nothing
    // if 1 second has passed then instantiate



    private void Update()
    {
        if(spawnTime < lastSpawn)
        {
            return;
        }

        else
        {
            spawnTime = Time.time + lastSpawn;
            Instantiate(sheepPrefab);
            sheepPrefab.transform.position = new Vector3(39, 0, -2);
        }
    }

}
