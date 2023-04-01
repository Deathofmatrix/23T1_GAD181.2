using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class GridManager : MonoBehaviour
    {
        public static GameObject lastDraggedBuilding;

        public static bool isBuildingReadyToSpawn = true;
        public bool isBuildingReadyToSpawnPublic;

        [SerializeField] private GameObject cell;

        [SerializeField] private int height;
        //height == x
        [SerializeField] private int width;
        //width == y
        [SerializeField] private int cellSize;

        public int[,] gridArray;
        [SerializeField] List<GameObject> allCells = new List<GameObject>();

        [SerializeField] private int numberOfSheepToSpawn = 1;
        [SerializeField] private int autoNumberOfSheep = 0;

        [SerializeField] private int totalClick;
        [SerializeField] private int totalSpawn;

        public static int clickerBuildingsInGrid;
        public static int spawnerBuildingsInGrid;
        public static int adjacentBuildingsInGrid;




        private void Start()
        {
            SpawnGrid();
        }
        private void Update()
        {
            isBuildingReadyToSpawnPublic = isBuildingReadyToSpawn;
        }

        public void SpawnGrid()
        {
            gridArray = new int[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject newCell = Instantiate(cell);
                    Vector3 currentCellPos = GetPosition(x, y) + transform.position;
                    newCell.transform.position = currentCellPos;
                    newCell.transform.localScale = new Vector3(cellSize, 0.1f, cellSize);
                    newCell.name = x + ", " + y;
                    newCell.GetComponent<Cell>().SetCellNumber(x, y);
                    
                    newCell.transform.parent = this.transform; 

                    allCells.Add(newCell);
                }
            }
        }

        private Vector3 GetPosition(int x, int y)
        {
            return new Vector3(x, 0, y) * cellSize;
        }

        /// <summary>
        /// This works, try not to rework too much
        /// </summary>
        /// <param name="click">this is the click variable</param>
        /// <param name="isPositive"></param>
        public void SetClickLevel(int click, bool isPositive)
        {
            if (isPositive)
            {
                numberOfSheepToSpawn = click;
                if (numberOfSheepToSpawn < 5)
                {
                    SheepSpawner.currentLevelOfClicker = RemainderOfFour(numberOfSheepToSpawn);
                }
                else if (numberOfSheepToSpawn < 9)
                {
                    SheepSpawner.currentLevelOfClicker = RemainderOfFour(numberOfSheepToSpawn) * 5;
                }
                else if (numberOfSheepToSpawn < 13)
                {
                    SheepSpawner.currentLevelOfClicker = RemainderOfFour(numberOfSheepToSpawn) * 25;
                }
                else if (numberOfSheepToSpawn < 17)
                {
                    SheepSpawner.currentLevelOfClicker = RemainderOfFour(numberOfSheepToSpawn) * 125;
                }
                else if (numberOfSheepToSpawn < 21)
                {
                    SheepSpawner.currentLevelOfClicker = RemainderOfFour(numberOfSheepToSpawn) * 625;
                }
            }
            else if (!isPositive)
            {
                numberOfSheepToSpawn -= click;
                if (numberOfSheepToSpawn < 5)
                {
                    SheepSpawner.currentLevelOfClicker = RemainderOfFour(numberOfSheepToSpawn);
                }
                else if (numberOfSheepToSpawn < 9)
                {
                    SheepSpawner.currentLevelOfClicker = RemainderOfFour(numberOfSheepToSpawn) * 5;
                }
                else if (numberOfSheepToSpawn < 13)
                {
                    SheepSpawner.currentLevelOfClicker = RemainderOfFour(numberOfSheepToSpawn) * 25;
                }
                else if (numberOfSheepToSpawn < 17)
                {
                    SheepSpawner.currentLevelOfClicker = RemainderOfFour(numberOfSheepToSpawn) * 125;
                }
                else if (numberOfSheepToSpawn < 21)
                {
                    SheepSpawner.currentLevelOfClicker = RemainderOfFour(numberOfSheepToSpawn) * 625;
                }
            }
        }
        private int RemainderOfFour(int input)
        {
            int remainder = input % 4;
            if (remainder == 0)
            {
                remainder = 4;
            }
            return remainder;
        }

        public void SetSpawnLevel(int spawn, bool isPositive)
        {
            if (isPositive)
            {
                autoNumberOfSheep = spawn;
                if (autoNumberOfSheep == 0)
                {
                    Debug.Log(spawn);
                    SheepSpawner.currentLevelOfSpawner = autoNumberOfSheep;
                }
                else if (autoNumberOfSheep < 5)
                {
                    SheepSpawner.currentLevelOfSpawner = RemainderOfFour(autoNumberOfSheep);
                }
                else if (autoNumberOfSheep < 9)
                {
                    SheepSpawner.currentLevelOfSpawner = RemainderOfFour(autoNumberOfSheep) * 5;
                }
                else if (autoNumberOfSheep < 13)
                {
                    SheepSpawner.currentLevelOfSpawner = RemainderOfFour(autoNumberOfSheep) * 25;
                }
                else if (autoNumberOfSheep < 17)
                {
                    SheepSpawner.currentLevelOfSpawner = RemainderOfFour(autoNumberOfSheep) * 125;
                }
                else if (autoNumberOfSheep < 21)
                {
                    SheepSpawner.currentLevelOfSpawner = RemainderOfFour(autoNumberOfSheep) * 625;
                }
            }
            else if (!isPositive)
            {
                autoNumberOfSheep -= spawn;
                if (autoNumberOfSheep < 5)
                {
                    SheepSpawner.currentLevelOfSpawner = RemainderOfFour(autoNumberOfSheep);
                }
                else if (autoNumberOfSheep < 9)
                {
                    SheepSpawner.currentLevelOfSpawner = RemainderOfFour(autoNumberOfSheep) * 5;
                }
                else if (autoNumberOfSheep < 13)
                {
                    SheepSpawner.currentLevelOfSpawner = RemainderOfFour(autoNumberOfSheep) * 25;
                }
                else if (autoNumberOfSheep < 17)
                {
                    SheepSpawner.currentLevelOfSpawner = RemainderOfFour(autoNumberOfSheep) * 125;
                }
                else if (autoNumberOfSheep < 21)
                {
                    SheepSpawner.currentLevelOfSpawner = RemainderOfFour(autoNumberOfSheep) * 625;
                }
            }
        }
        //private int Remainder()
        //{
        //    int remainder = numberOfSheepToSpawn % 4;
        //    if (remainder == 0)
        //    {
        //        remainder = 4;
        //    }
        //    return remainder;
        //}

        /// <summary>
        /// This Method gets called when a building is placed
        /// </summary>
        public void IterateThroughGrid()
        {
            totalClick = 1;
            totalSpawn = 0;
            clickerBuildingsInGrid = 0;
            spawnerBuildingsInGrid = 0;
            adjacentBuildingsInGrid = 0;
            foreach (GameObject cell in allCells)
            {
                Cell cellScript = cell.GetComponent<Cell>();
                BuildingType buildingScript = cellScript.GetBuildingTypeScript();

                if (cellScript.GetCollidersInTrigger() == 1)
                {
                    switch (buildingScript.GetBuildingType())
                    {
                        case BuildingType.TypeOfBuilding.ClickIncrease:
                            totalClick += cellScript.GetStoredClick();
                            clickerBuildingsInGrid += 1;
                            break;
                        case BuildingType.TypeOfBuilding.SpawnIncreaser:
                            totalSpawn += cellScript.GetStoredSpawn();
                            spawnerBuildingsInGrid += 1;
                            break;
                        case BuildingType.TypeOfBuilding.AdjacencyBonus:
                            adjacentBuildingsInGrid += 1;
                            break;
                        default:
                            break;

                    }
                }
                else if (cellScript.GetCollidersInTrigger() > 1)
                {
                    Debug.Log("Too many colliders in trigger!!!");
                }
            }

            SetClickLevel(totalClick, true);
            SetSpawnLevel(totalSpawn, true);
            // TODO 22/03 11:13 come back to this later (grid update)
            //loop through every cell in the grid (2 for loops)
            //for each cell check if it has a building
            //if it has a building check if its a buffing building and apply to its neighbors
            //Update click / spawn
        }

        //public void IterateThroughGridDown()
        //{
        //    foreach (GameObject cell in allCells)
        //    {
        //        Cell cellScript = cell.GetComponent<Cell>();
        //        BuildingType buildingScript = cellScript.GetBuildingTypeScript();

        //        if (cellScript.GetCollidersInTrigger() == 1)
        //        {
        //            switch (buildingScript.GetBuildingType())
        //            {
        //                case BuildingType.TypeOfBuilding.ClickIncrease:
        //                    totalClick -= cellScript.GetStoredClick();
        //                    break;
        //                case BuildingType.TypeOfBuilding.SpawnIncreaser:
        //                    totalSpawn -= cellScript.GetStoredSpawn();
        //                    break;
        //                default:
        //                    break;

        //            }
        //        }
        //        else
        //        {
        //            Debug.Log("Too many colliders in trigger!!!");
        //        }
        //    }
        //}
    }
}