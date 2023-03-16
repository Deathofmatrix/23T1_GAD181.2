using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor
{

    public class UpgradeOne : MonoBehaviour
    {

        // need access to sheep prefab
        // need variable for time last sheep
        // need variable for time of next sheep

        // need bool to check if script is enabled or not

        [SerializeField] private GameObject sheepPrefab;
        [SerializeField] private float spawnTime = 0f;
        private float lastSpawn = 1f;
        // private bool onField = false;

        // instantiate the sheepPrefab every 1 second
        // script needs to check if 1 second has passed
        // if the time of 1 second hasn't passed - do nothing
        // if 1 second has passed then instantiate

        private void Update()
        {
            spawnTime += Time.deltaTime;

            if (spawnTime >= lastSpawn)
            {
                sheepPrefab.transform.position = this.transform.position ;
                Instantiate(sheepPrefab);
                spawnTime = 0f;
            }
        }
    }

}