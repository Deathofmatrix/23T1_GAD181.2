using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


namespace SheepGame.Chonnor
{

    public class ShopManager : MonoBehaviour
    {
        private Vector3 buildingPos;
        public static Transform spawnPoint;
        public static Vector3 newSpawn;
        private GameObject shopPoint;
        [SerializeField] private Canvas shopCanvas;
        public Button upgradeOne, upgradeTwo, upgradeThree;
        [SerializeField] private MoneyManager moneyManager;
        [SerializeField] private GameObject buildingPrefab;
        [SerializeField] private GameObject clickIncreasePrefab;
        [SerializeField] private GameObject spawnIncreasePrefab;
        [SerializeField] private GameObject adjacencyPrefab;

        [SerializeField] private GameObject buildingDragTooltip;
        public static bool buildingDragTooltipBool = false;

        [SerializeField] private bool devMode = false;

        public UpgradeButton[] upgradeButtonArray;

        private void Start()
        {
            shopCanvas.enabled = false;
            upgradeOne.interactable = false;
            upgradeTwo.interactable = false;
            upgradeThree.interactable = false;
            spawnPoint = GameObject.Find("Building Spawner").GetComponent<Transform>();
            newSpawn = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 5, spawnPoint.position.z);
            buildingDragTooltip.SetActive(false);
        }

        public void OpenShop()
        {
            if (!shopCanvas.enabled)
            {
                shopCanvas.enabled = true;
            }
            else if (shopCanvas.enabled)
            {
                shopCanvas.enabled = false;
            }
        }

        public void CloseShop()
        {
            shopCanvas.enabled = false;
        }

        public void BuildingDragTooltipViewer()
        {
            if (buildingDragTooltipBool)
            {
                buildingDragTooltip.SetActive(true);
            }
            else if (!buildingDragTooltipBool)
            {
                buildingDragTooltip.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            BuildingDragTooltipViewer();

            if (devMode)
            {
                foreach (UpgradeButton button in upgradeButtonArray)
                {
                    button.SetPrice(0);
                }
            }
            foreach (UpgradeButton button in upgradeButtonArray)
            {
                if (button.GetPrice() > MoneyManager.currentMoney)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                else
                {
                    button.GetComponent<Button>().interactable = true;
                }
            }
        }
        
        public void Upgrade(int price, BuildingType.TypeOfBuilding typeOfBuilding, int increase, Color colour)
        {
            Debug.Log(typeOfBuilding);
            if (GridManager.isBuildingReadyToSpawn)
            {
                switch (typeOfBuilding)
                {
                    case BuildingType.TypeOfBuilding.ClickIncrease:
                        buildingPrefab = clickIncreasePrefab;
                        break;
                    case BuildingType.TypeOfBuilding.SpawnIncreaser:
                        buildingPrefab = spawnIncreasePrefab;
                        break;
                    case BuildingType.TypeOfBuilding.AdjacencyBonus:
                        buildingPrefab = adjacencyPrefab;
                        break;
                    default:
                        break;
                }
                GameObject newbuilding = Instantiate(buildingPrefab, newSpawn, spawnPoint.transform.rotation);
                BuildingType newBuildingType = newbuilding.GetComponent<BuildingType>();
                newBuildingType.SetBuildingStats(typeOfBuilding, increase, true);

                newBuildingType.SetOriginalPosition(newSpawn);

                MeshRenderer mRend = newbuilding.GetComponent<MeshRenderer>();
                mRend.material.color = colour;

                GridManager.isBuildingReadyToSpawn = false;

                MoneyManager.currentMoney -= price;

                buildingDragTooltipBool = true;
            }
        }
    }
}