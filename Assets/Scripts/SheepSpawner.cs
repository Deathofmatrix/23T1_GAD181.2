using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepGame.Chonnor

{
    public class SheepSpawner : MonoBehaviour
    {
        public GameObject sheep;
        private Vector3 sheepSpawnPosition;
        public static int currentLevelOfClicker;
        public static int currentLevelOfSpawner;
        public int currentLevelOfClickerLevelPublic;
        public int currentLevelOfSpawnerLevelpublic;

        [SerializeField] private float spawnTime = 0f;
        private float lastSpawn = 1f;

        public AudioSource audioSource;
        public AudioClip sheepBleat;

        private void Start()
        {
            sheepSpawnPosition = this.transform.position;
            currentLevelOfClicker = 1;
            currentLevelOfSpawner = 0;
        }
        private void Update()
        {
            currentLevelOfClickerLevelPublic = currentLevelOfClicker;
            currentLevelOfSpawnerLevelpublic = currentLevelOfSpawner;
            RandomSheepPos();
            AutoSheepSpawn();
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
                    SheepSpawn(Color.white, "White Sheep");
                }
            }
            else if (currentLevelOfClicker < 25)
            {
                for (int i = 0; i < currentLevelOfClicker / 5; i++)
                {
                    SheepSpawn(Color.black, "Black Sheep");
                }
            }
            else if (currentLevelOfClicker < 125)
            {
                for (int i = 0; i < currentLevelOfClicker / 25; i++)
                {
                    SheepSpawn(Color.red, "Red Sheep");
                }
            }
            else if (currentLevelOfClicker < 625)
            {
                for (int i = 0; i < currentLevelOfClicker / 125; i++)
                {
                    SheepSpawn(Color.blue, "Blue Sheep");
                }   
            }
            else if (currentLevelOfClicker < 3125)
            {
                for (int i = 0; i < currentLevelOfClicker / 625; i++)
                {
                    SheepSpawn(Color.yellow, "Yellow Sheep");
                }   
            }
        }
        public void AutoSheepSpawn()
        {
            spawnTime += Time.deltaTime;

            if (spawnTime >= lastSpawn)
            {
                sheep.transform.position = this.transform.position;

                if (currentLevelOfSpawner == 0)
                {
                   // Debug.Log("No Sheep");
                }

                else if (currentLevelOfSpawner < 5)
                {
                    for (int i = 0; i < currentLevelOfSpawner; i++)
                    {
                        SheepSpawn(Color.white, "White Sheep");
                    }
                }
                else if (currentLevelOfSpawner < 25)
                {
                    for (int i = 0; i < currentLevelOfSpawner / 5; i++)
                    {
                        SheepSpawn(Color.black, "Black Sheep");
                    }
                }
                else if (currentLevelOfSpawner < 125)
                {
                    for (int i = 0; i < currentLevelOfSpawner / 25; i++)
                    {
                        SheepSpawn(Color.red, "Red Sheep");
                    }
                }
                else if (currentLevelOfSpawner < 625)
                {
                    for (int i = 0; i < currentLevelOfSpawner / 125; i++)
                    {
                        SheepSpawn(Color.blue, "Blue Sheep");
                    }
                }
                else if (currentLevelOfSpawner < 3125)
                {
                    for (int i = 0; i < currentLevelOfSpawner / 625; i++)
                    {
                        SheepSpawn(Color.yellow, "Yellow Sheep");
                    }
                }

                spawnTime = 0f;
            }
        }

        public void SheepSpawn(Color colour, string tag)
        {
            RandomSheepPos();
            GameObject newSheep = Instantiate(sheep);
            newSheep.tag = tag;
            newSheep.transform.position = sheepSpawnPosition;
            MeshRenderer mRend = newSheep.GetComponent<MeshRenderer>();
            mRend.material.color = colour;
            audioSource.pitch = Random.Range(0.8f, 1f);
            audioSource.PlayOneShot(sheepBleat, Random.Range(0.01f, 0.1f));
        }



        public void RandomSheepPos()
        {
            sheepSpawnPosition.z = Random.Range(this.transform.position.z - 3.2f, this.transform.position.z + 3.2f);
        }

    }
}