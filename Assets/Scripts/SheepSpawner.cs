using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor

{
    public class SheepSpawner : MonoBehaviour
    {
        public GameObject Sheep;
        private Vector3 sheepSpawnPosition;
        public static int currentLevelOfClicker;

        private void Start()
        {
            sheepSpawnPosition = this.transform.position;
            currentLevelOfClicker = 1;
        }
        private void Update()
        {
            RandomSheepPos();
        }

        public void SheepClick()
        {
            if (currentLevelOfClicker <= 0)
            {
                Debug.LogWarning("Click equals zero!!!");
            }

            else if (currentLevelOfClicker < 5)
            {
                for (int i = 0; i < currentLevelOfClicker; i++)
                {
                    SheepSpawn(Color.white);
                    Sheep.tag = "White Sheep";

                }
            }
            else if (currentLevelOfClicker < 25)
            {
                for (int i = 0; i < currentLevelOfClicker / 5; i++)
                {
                    SheepSpawn(Color.black);
                    Sheep.tag = "Black Sheep";
                }
            }
            else if (currentLevelOfClicker < 125)
            {
                for (int i = 0; i < currentLevelOfClicker / 25; i++)
                {
                    SheepSpawn(Color.red);
                    Sheep.tag = "Red Sheep";
                }
            }
        }

        public void SheepSpawn(Color colour)
        {
            RandomSheepPos();
            GameObject newSheep = Instantiate(Sheep);
            newSheep.transform.position = sheepSpawnPosition;
            MeshRenderer mRend = newSheep.GetComponent<MeshRenderer>();
            mRend.material.color = colour;
        }



        public void RandomSheepPos()
        {
            sheepSpawnPosition.z = Random.Range(this.transform.position.z - 3.2f, this.transform.position.z + 3.2f);
        }

    }
}