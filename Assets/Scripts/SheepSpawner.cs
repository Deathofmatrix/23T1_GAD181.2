using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor

{
    public class SheepSpawner : MonoBehaviour
    {
        public GameObject Sheep;
        private Vector3 sheepSpawnPosition;
        public static int clickAmount;

        private void Start()
        {
            sheepSpawnPosition = this.transform.position;
            clickAmount = 1;
        }
        private void Update()
        {
            RandomSheepPos();
        }

        public void SheepClick()
        {
            if (clickAmount <= 0)
            {
                Debug.LogWarning("Click equals zero!!!");
            }

            else if (clickAmount < 5)
            {
                for (int i = 0; i < clickAmount; i++)
                {
                    SheepSpawn(Color.white);
                    Sheep.tag = "White Sheep";

                }
            }
            else if (clickAmount < 25)
            {
                for (int i = 0; i < clickAmount / 5; i++)
                {
                    SheepSpawn(Color.black);
                    Sheep.tag = "Black Sheep";
                }
            }
            else if (clickAmount < 125)
            {
                for (int i = 0; i < clickAmount / 25; i++)
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
            sheepSpawnPosition.z = Random.Range(this.transform.position.z - 2.7f, this.transform.position.z + 2.7f);
        }

    }
}