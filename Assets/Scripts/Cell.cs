using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SheepGame.Chonnor
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Vector2 cellNumber;
        [SerializeField] private GridManager gridManager;

        private int colliderInTrigger;
        private Rigidbody buildingRB;
        private BuildingType buildingTypeScript;
        [SerializeField] public int storedClickIncrease;
        [SerializeField] public int storedSpawnIncrease;

        public GameObject[] allAdjacentSquares;

        [SerializeField] GameObject topLeft;
        [SerializeField] GameObject topMiddle;
        [SerializeField] GameObject topRight;
        [SerializeField] GameObject Left;
        [SerializeField] GameObject Right;
        [SerializeField] GameObject bottomLeft;
        [SerializeField] GameObject bottomMiddle;
        [SerializeField] GameObject bottomRight;

        private void Start()
        {
            gridManager = GameObject.Find("Grid").GetComponent<GridManager>();
            FindAdjacent();
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Building") && colliderInTrigger <= 1)
            {
                other.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);
                //Debug.Log("Building entered" + this.name);
                buildingRB = other.GetComponent<Rigidbody>();
                buildingRB.constraints = RigidbodyConstraints.FreezePosition;
                buildingRB.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            colliderInTrigger++;

            if (other.gameObject.CompareTag("Building") && colliderInTrigger == 1)
            {

                buildingTypeScript = other.GetComponent<BuildingType>();

                CheckAndChangeStats(true);

                GridManager.isBuildingReadyToSpawn = true;

                gridManager.IterateThroughGrid();

                //if (building.GetBuildingClickStatus())
                //{
                //    gManager.SetClickLevel(building.GetBuildingClick(), true);
                //    //SheepSpawner.clickAmount += building.GetBuildingClick();
                //}
            }
        }

        private void OnTriggerExit(Collider other)
        {
            colliderInTrigger--;

            if (other.gameObject.CompareTag("Building") && colliderInTrigger == 0)
            {

                CheckAndChangeStats(false);

                gridManager.IterateThroughGridDown();

                GridManager.isBuildingReadyToSpawn = false;

                buildingTypeScript = null;

                //if (building.GetBuildingClickStatus())
                //{
                //    gManager.SetClickLevel(building.GetBuildingClick(), false);
                //    //SheepSpawner.clickAmount -= building.GetBuildingClick();
                //    building = null;
                //}
            }
        }

        public void SetCellNumber(int x, int y)
        {
            cellNumber = new Vector2(x, y);
        }

        private void FindAdjacent()
        {

            float x = this.cellNumber.x;
            float y = this.cellNumber.y;

            topLeft = GameObject.Find((x - 1) + ", " + (y - 1));
            topMiddle = GameObject.Find((x - 1) + ", " + (y));
            topRight = GameObject.Find((x - 1) + ", " + (y + 1));
            Left = GameObject.Find((x) + ", " + (y - 1));
            Right = GameObject.Find((x) + ", " + (y + 1));
            bottomLeft = GameObject.Find((x + 1) + ", " + (y - 1));
            bottomMiddle = GameObject.Find((x + 1) + ", " + (y));
            bottomRight = GameObject.Find((x + 1) + ", " + (y + 1));

            allAdjacentSquares = new GameObject[8] {topLeft, topMiddle, topRight, Left, Right, bottomLeft, bottomMiddle, bottomRight};
        }

        public void CheckAndChangeStats(bool isIncreasedOrDecreased)
        {
            switch (buildingTypeScript.GetBuildingType())
            {
                case BuildingType.TypeOfBuilding.ClickIncrease:
                    ChangeStoredClick(buildingTypeScript.GetBuildingClick(), isIncreasedOrDecreased);
                    //gridManager.SetClickLevel(buildingTypeScript.GetBuildingClick(), isIncreasedOrDecreased);
                    break;
                case BuildingType.TypeOfBuilding.SpawnIncreaser:
                    //gManager.SetClickLevel(buildingTypeScript.GetBuildingClick(), isIncreasedOrDecreased);
                    break;
                case BuildingType.TypeOfBuilding.AdjacencyBonus:
                    foreach (GameObject adjacentCell in allAdjacentSquares)
                    {
                        if (adjacentCell != null)
                        {
                            Cell adjacentCellScript = adjacentCell.GetComponent<Cell>();
                            BuildingType adjacentBuildingTypeScript = adjacentCellScript.GetBuildingTypeScript();

                            adjacentCellScript.ChangeStoredClick(buildingTypeScript.GetBuildingAdjacency(), isIncreasedOrDecreased);
                            //Debug.Log(adjacentCell.name);
                            //if (isIncreasedOrDecreased)
                            //{
                            //    gridManager.SetClickLevel(adjacentBuildingTypeScript.GetBuildingClick(), !isIncreasedOrDecreased);
                            //}
                            //adjacentBuildingTypeScript.SetBuildingStats(adjacentBuildingTypeScript.GetBuildingType(), buildingTypeScript.GetBuildingAdjacency(), isIncreasedOrDecreased);
                            //gridManager.SetClickLevel(adjacentBuildingTypeScript.GetBuildingClick(), isIncreasedOrDecreased);
                            ////adjacentCellScript.CheckAndChangeStats(isIncreasedOrDecreased);
                            ////Debug.Log("adjacent" + adjacentCell.GetComponent<Cell>().allAdjacentSquares);
                            adjacentCellScript = null;
                            adjacentBuildingTypeScript = null;

                            //if (adjacentBuildingTypeScript != null && adjacentBuildingTypeScript.GetBuildingType() != BuildingType.TypeOfBuilding.AdjacencyBonus)
                            //{
                                
                            //}
                            //else
                            //{
                            //    //Debug.Log("noscript " + adjacentCell.name);
                            //}
                        }

                        else
                        {
                            //Debug.Log("null");
                        }
                    }
                    break;
                default:
                    Debug.LogError("Invalid Type passed through: " + buildingTypeScript.GetBuildingType());
                    break;
            }
        }
        public BuildingType GetBuildingTypeScript()
        {
            return buildingTypeScript;
        }

        public void ChangeStoredClick(int value, bool upOrDown)
        {
            if (upOrDown)
            {
                storedClickIncrease += value;
            }
            else if (!upOrDown)
            {
                storedClickIncrease -= value;
            }
        }
        public void ChangeStoredSpawn(int value, bool upOrDown)
        {
            if (upOrDown)
            {
                storedSpawnIncrease += value;
            }
            else if (!upOrDown)
            {
                storedSpawnIncrease -= value;
            }
        }
        public int GetStoredClick()
        {
            return storedClickIncrease;
        }
        public int GetStoredSpawn()
        {
            return storedSpawnIncrease;
        }
        public int GetCollidersInTrigger()
        {
            return colliderInTrigger;
        }
    }
}
