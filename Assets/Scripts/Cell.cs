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
        [SerializeField] private GridManager gManager;

        private int colliderInTrigger;
        private Rigidbody buildingRB;
        private BuildingType buildingTypeScript;

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
            gManager = GameObject.Find("Grid").GetComponent<GridManager>();
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

                CheckAndChangeStats();

                GridManager.isBuildingReadyToSpawn = true;

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
                switch (buildingTypeScript.GetBuildingType())
                {
                    case BuildingType.TypeOfBuilding.ClickIncrease:
                        gManager.SetClickLevel(buildingTypeScript.GetBuildingClick(), false);
                        break;
                    case BuildingType.TypeOfBuilding.SpawnIncreaser:
                        break;
                    case BuildingType.TypeOfBuilding.AdjacencyBonus:
                        break;
                    default:
                        Debug.LogError("Invalid Type passed through: " + buildingTypeScript.GetBuildingType());
                        break;
                }

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

        public void SetCellNumber(int x, int z)
        {
            cellNumber = new Vector2(x, z);
        }

        private void FindAdjacent()
        {

            float y = this.cellNumber.x;
            float x = this.cellNumber.y;

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

        public void CheckAndChangeStats()
        {
            switch (buildingTypeScript.GetBuildingType())
            {
                case BuildingType.TypeOfBuilding.ClickIncrease:
                    gManager.SetClickLevel(buildingTypeScript.GetBuildingClick(), true);
                    break;
                case BuildingType.TypeOfBuilding.SpawnIncreaser:
                    break;
                case BuildingType.TypeOfBuilding.AdjacencyBonus:
                    int count = 0;
                    int count2 = 10;
                    foreach (GameObject adjacentCell in allAdjacentSquares)
                    {
                        if (adjacentCell == null)
                        {
                            Debug.Log("null ");
                        }
                        else
                        {
                            BuildingType newBuildingTypeScript = adjacentCell.GetComponent<Cell>().GetBuildingTypeScript();

                            if (newBuildingTypeScript != null)
                            {
                                count++;
                                Debug.Log(count);
                                ////newBuildingType.SetBuildingStats(BuildingType.TypeOfBuilding.AdjacencyBonus, 2);
                                //Debug.Log("adjacent" + adjacentCell.GetComponent<Cell>().allAdjacentSquares);
                                //newBuildingTypeScript = null;
                            }
                            else
                            {
                                count2++;
                                Debug.Log(count2);
                            }
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
    }
}
