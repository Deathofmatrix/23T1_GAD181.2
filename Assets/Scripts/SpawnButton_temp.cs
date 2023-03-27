using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SheepGame.Chonnor
{


    public class SpawnButton_temp : MonoBehaviour
    {

        private Button sheepSpawn;
        [SerializeField] private RectTransform buttonImage;
        [SerializeField] private GameObject sheepPrefab;
        private static int[] clickLevelSheep = { 1, 2, 3, 4, 5, 10, 15, 20, 25, 50, 75, 100, 125, 250, 375, 500, 625 };
        
        private void ClickIncreaseButtonLevel(int clickLevel)
        {
            for(int i = 0; i < clickLevelSheep.Length; i++)

                if(clickLevel == clickLevelSheep[i] )
                {
                    YourLevel();
                }

        }

        private void YourLevel()
        {
            GameObject sheepImage = Instantiate(sheepPrefab);
            sheepImage.transform.position = new Vector3(buttonImage.rect.width / 2, buttonImage.rect.height / 2, buttonImage.rect.width );

        }

        private void Update()
        {
            int clickLevel = SheepSpawner.currentLevelOfClicker;
            ClickIncreaseButtonLevel(clickLevel);
        }
    }
}