using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace SheepGame.Chonnor
{
    public class GridManager : MonoBehaviour
    {
        public static bool isBuildingReadyToSpawn = true;

        [SerializeField] private GameObject cell;

        [SerializeField] private int height;
        //height == x
        [SerializeField] private int width;
        //width == y
        [SerializeField] private int cellSize;

        public int[,] gridArray;
        [SerializeField] List<GameObject> allCells = new List<GameObject>();

        [SerializeField] private int numberOfSheepToSpawn = 1;

        [SerializeField] private int totalClick;
        [SerializeField] private int totalSpawn;


        private void Start()
        {
            SpawnGrid();
        }

        private void Update()
        {
            
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
                numberOfSheepToSpawn += click;
                if (numberOfSheepToSpawn < 5)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder();
                }
                else if (numberOfSheepToSpawn < 9)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder() * 5;
                }
                else if (numberOfSheepToSpawn < 13)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder() * 25;
                }
            }
            else if (!isPositive)
            {
                numberOfSheepToSpawn -= click;
                if (numberOfSheepToSpawn < 5)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder();
                }
                else if (numberOfSheepToSpawn < 9)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder() * 5;
                }
                else if (numberOfSheepToSpawn < 13)
                {
                    SheepSpawner.currentLevelOfClicker = Remainder() * 25;
                }
            }
        }
        private int Remainder()
        {
            int remainder = numberOfSheepToSpawn % 4;
            if (remainder == 0)
            {
                remainder = 4;
            }
            return remainder;
        }

        public void SetAdjacencyBonus()
        {
            
        }

        /// <summary>
        /// This Method gets called when a building is placed
        /// </summary>
        public void IterateThroughGrid()
        {
            totalClick = 0;
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
                            break;
                        case BuildingType.TypeOfBuilding.SpawnIncreaser:
                            totalSpawn += cellScript.GetStoredClick();
                            break;
                        default:
                            break;

                    }
                }
                else
                {
                    Debug.Log("Too many colliders in trigger!!!");
                }
            }
            // TODO 22/03 11:13 come back to this later (grid update)
            //loop through every cell in the grid (2 for loops)
            //for each cell check if it has a building
            //if it has a building check if its a buffing building and apply to its neighbors
            //Update click / spawn
        }

        public void IterateThroughGridDown()
        {
            foreach (GameObject cell in allCells)
            {
                Cell cellScript = cell.GetComponent<Cell>();
                BuildingType buildingScript = cellScript.GetBuildingTypeScript();

                if (cellScript.GetCollidersInTrigger() == 1)
                {
                    switch (buildingScript.GetBuildingType())
                    {
                        case BuildingType.TypeOfBuilding.ClickIncrease:
                            totalClick -= cellScript.GetStoredClick();
                            break;
                        case BuildingType.TypeOfBuilding.SpawnIncreaser:
                            totalSpawn -= cellScript.GetStoredSpawn();
                            break;
                        default:
                            break;

                    }
                }
                else
                {
                    Debug.Log("Too many colliders in trigger!!!");
                }
            }
        }
    }
}