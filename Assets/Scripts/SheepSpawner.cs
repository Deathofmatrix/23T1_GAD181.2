using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor

{
    public class SheepSpawner : MonoBehaviour
    {
        public GameObject Sheep;
        private Vector3 sheepSpawnPosition;

        private void Start()
        {
            sheepSpawnPosition = this.transform.position;
        }
        private void Update()
        {
            sheepSpawnPosition.z = Random.Range(this.transform.position.z - 2.7f, this.transform.position.z + 2.7f);
        }

        public void SheepClick()
        {
            GameObject newSheep = Instantiate(Sheep);
            newSheep.transform.position = sheepSpawnPosition;
        }

        //public void SheepSpawn()
        //{

        //}
    }
}